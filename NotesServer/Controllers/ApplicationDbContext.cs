using Microsoft.EntityFrameworkCore;
using NotesServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesServer.Controllers
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-O6O2RKO;Database=Notes_remote_db;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public DbSet<Note> Notes { get; set; }
    }
}
