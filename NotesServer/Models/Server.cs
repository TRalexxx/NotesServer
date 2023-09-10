using NotesServer.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NotesServer.Models
{
    public class Server
    {
        private IPEndPoint _ipEndp { get; set; }
        private Socket _socket { get; set; }

        ApplicationDbContext _context { get; set; }

        public Server(string addresStr, int port)
        {
            _ipEndp = new IPEndPoint(IPAddress.Parse(addresStr), port);

            _context = new ApplicationDbContext();
        }

        void MyAcceptCallbackFunction(IAsyncResult ia)
        {
            try
            {
                Socket ns = (Socket)ia.AsyncState;
                Socket clientSocket = ns.EndAccept(ia);
                Console.WriteLine(ns.LocalEndPoint.ToString());
                while (true)
                {

                    byte[] bytes = new byte[1024];

                    int l = clientSocket.Receive(bytes);

                    if (l > 0)
                    {
                        string recieveStr = Encoding.Unicode.GetString(bytes, 0, l);

                        Note note = JsonSerializer.Deserialize<Note>(recieveStr);

                        _context.Notes.Add(note);
                        _context.SaveChangesAsync();

                        clientSocket.Send(Encoding.Unicode.GetBytes("Note saved"));
                    }

                    ns.BeginAccept(new AsyncCallback(MyAcceptCallbackFunction), ns);

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw;
            }
            //finally
            //{
            //    ns.Shutdown(SocketShutdown.Send);
            //    ns.Close();

            //}

        }

        public void StartServer()
        {
            if (_socket != null)
            {
                return;
            }

            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.Bind(_ipEndp);
            _socket.Listen();

            Console.WriteLine("Server started");

            _socket.BeginAccept(new AsyncCallback(MyAcceptCallbackFunction), _socket);
        }

    }
}
