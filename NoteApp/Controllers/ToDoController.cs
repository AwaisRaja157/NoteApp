using NoteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoteApp.Controllers
{
    public class ToDoController : Controller
    {
        [HttpGet]
        public ActionResult AddToDo(int ID = 0)
        {
            ToDo todo = new ToDo();
            using (var context = new NoteAppContext())
            {
                if (ID != 0)
                {
                    todo = context.ToDoS.Where(x => x.ID == ID).FirstOrDefault();
                }
                
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddToDo(ToDo todo)
        {
            using (var context = new NoteAppContext())
            {
                if (todo.ID == 0)
                {
                    context.ToDoS.Add(todo);
                }
                else
                {
                    var tod = context.ToDoS.Where(x => x.ID == todo.ID).FirstOrDefault();
                    tod.ID = tod.ID;
                    tod.Title = tod.Title;
                    tod.Description = tod.Description;
                }
                
                context.SaveChanges();
            }
            return RedirectToAction("AddToDO", "ToDo");
        }
        [HttpPost]
        public ActionResult DeleteToDo(int ID)
        {
            using (var context = new NoteAppContext())
            {
               var todo = context.ToDoS.Where(x => x.ID == ID).FirstOrDefault();
                context.ToDoS.Remove(todo);
            }

            return RedirectToAction("GetToDoList", "ToDo");
        }
        [HttpGet]
        public ActionResult GetToDoList()
        {
            List<ToDo> todo = new List<ToDo>();
            using (var Context = new NoteAppContext())
            {
                todo = Context.ToDoS.ToList();
            }
            return View(todo);
        }
    }
}