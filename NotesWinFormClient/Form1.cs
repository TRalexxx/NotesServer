using Microsoft.EntityFrameworkCore;
using NotesServer.Controllers;
using NotesServer.Models;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace NotesWinFormClient
{
    public partial class Form1 : Form
    {
        ApplicationDbContext context;

        List<Note> notes;

        const int PORT = 4444;
        const string IP = "127.0.0.1";
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public Form1()
        {
            InitializeComponent();
        }

        private async void RefreshNotesListBtn_Click(object sender, EventArgs e)
        {
            using (context = new ApplicationDbContext())
            {
                notes = new List<Note>();

                notes = await context.Notes.ToListAsync();

                NotesLB.Items.Clear();

                foreach (Note note in notes)
                {
                    NotesLB.Items.Add(note.Title);
                }
            }
        }

        private void NotesLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (context = new ApplicationDbContext())
            {
                if (NotesLB.SelectedIndex > -1 && NotesLB.SelectedItem != null)
                {
                    Note note = notes.FirstOrDefault(x => x.Title.Equals(NotesLB.SelectedItem));

                    NoteTitleTB.Text = note.Title;
                    NoteTextTB.Text = note.Text;
                }
            }
        }

        private void AddNewNoteBtn_Click(object sender, EventArgs e)
        {
            notes.Add(new Note());

            NoteTitleTB.Text = string.Empty;
            NoteTextTB.Text = string.Empty;
        }

        private async void SaveNoteBtn_ClickAsync(object sender, EventArgs e)
        {
            Note note = new Note();
            note.Title = NoteTitleTB.Text;
            note.Text = NoteTextTB.Text;

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                await socket.ConnectAsync(IP, PORT);

                string sendStr = JsonSerializer.Serialize(note);

                socket.Send(Encoding.Unicode.GetBytes(sendStr));

                byte[] data = new byte[256];

                int l = socket.Receive(data);

                if (l > 0)
                {
                    string recieveStr = Encoding.Unicode.GetString(data, 0, l);

                    MessageBox.Show($"{recieveStr}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Something goes wrong", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            socket.Close();
        }
    }
}