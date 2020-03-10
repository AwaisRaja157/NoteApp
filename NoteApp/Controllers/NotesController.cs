using NoteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoteApp.Controllers
{
    public class NotesController : Controller
    {
        [HttpGet]
        public ActionResult AddNotes(int ID = 0)
        {
            Note note = new Note();
            using (var context = new NoteAppContext())
            {
                if (ID != 0)
                {
                    note = context.Notes.Where(x => x.ID == ID).FirstOrDefault();
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddNotes(Note note)
        {
            using (var Context = new NoteAppContext())
            {
                if (note.ID == 0)
                {
                    Context.Notes.Add(note);
                }
                else
                {
                    var not = Context.Notes.Where(x => x.ID == note.ID).FirstOrDefault();
                    not.ID = not.ID;
                    not.Title = not.Title;
                    not.Description = not.Description;
                }
               
                Context.SaveChanges();
            }
            return RedirectToAction("AddNotes","Notes");
        }
        [HttpPost]
        public ActionResult DeleteNotes(int ID)
        {
            using (var context = new NoteAppContext())
            {
                var note = context.Notes.Where(x => x.ID == ID).FirstOrDefault();
                context.Notes.Remove(note);
                context.SaveChanges();
            }
            return RedirectToAction("AddNotes", "Notes");
        }
        [HttpGet]
        public ActionResult GetNotesList()
        {
            List<Note> notes = new List<Note>();
            using (var context = new NoteAppContext())
            {
                notes = context.Notes.ToList();
            }
            return View(notes);
        }
    }
}