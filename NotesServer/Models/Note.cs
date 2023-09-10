using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesServer.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Text { get; set; } = default!;
    }
}
