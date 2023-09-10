using NotesServer.Models;

string addr = "127.0.0.1";
int port = 4444;

Server server = new Server(addr, port);

server.StartServer();

Console.Read();