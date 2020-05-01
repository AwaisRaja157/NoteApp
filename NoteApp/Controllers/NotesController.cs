using NoteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;


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
        public JsonResult AddNotes(Note note)
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
            return Json(note.ID);
        }

        [HttpPost]
        public ActionResult AddFiles(List<HttpPostedFileBase> files, int noteId)
        {
            try
            {
                if (files != null)
                {
                    List<string> file = new List<string>();
                    string path = Server.MapPath("~/Files/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    foreach (var item in files)
                    {
                        item.SaveAs(path + Path.GetFileName(item.FileName));

                        ViewBag.Message = "File uploaded successfully.";
                        string savelocation = "~/Files/" + Path.GetFileName(item.FileName);
                        file.Add(savelocation);

                    }

                    foreach (var item in file)
                    {
                        NoteFile noteFile = new NoteFile();
                        noteFile.NoteID = noteId;
                        noteFile.Filepath = item;
                        using (var context = new NoteAppContext())
                        {
                            context.NoteFiles.Add(noteFile);
                            context.SaveChanges();

                        }
                    }


                }


            }

            catch (Exception ex)

            {

            }

            return View();
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


        public ActionResult DeleteNotes(int ID)
        {
            using (var context = new NoteAppContext())
            {
                var note = context.Notes.Where(x => x.ID == ID).FirstOrDefault();
                context.Notes.Remove(note);
                context.SaveChanges();
            }

            return RedirectToAction("GetNotesList", "Notes");
        }

    }
}