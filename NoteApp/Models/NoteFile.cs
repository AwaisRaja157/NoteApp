using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoteApp.Models
{
    [Table("NoteFile", Schema = "Notes")]
    public class NoteFile
    {
        [Key]
        public int ID { get; set; }
        public int NoteID { get; set; }
        public string Filepath { get; set; }
        public string Imagepath { get; set; }
    }
}