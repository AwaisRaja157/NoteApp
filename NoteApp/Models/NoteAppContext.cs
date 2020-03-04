using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NoteApp.Models
{
    public class NoteAppContext : DbContext
    {
        public NoteAppContext() : base ("DefaultConnectionString")
        {

        }
        
        public DbSet<User> Users { get; set; }
    }
}