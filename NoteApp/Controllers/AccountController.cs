using NoteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoteApp.Controllers
{
    public class AccountController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Login(String Email, String Password)
        {
            using (var Context = new NoteAppContext())
            {
                var user = Context.Users.Where(x => x.Email == Email && x.Password == Password).FirstOrDefault();
                if (user != null)
                {
                    Session["User"] = user;

                }
            }
            
            return RedirectToAction("Dashboard","Dashboard");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            using(var Context = new NoteAppContext())
            {
                Context.Users.Add(user);
                Context.SaveChanges();

            }
            return RedirectToAction("Register", "Account");
        }

        [HttpGet]
        public ActionResult GetUserList()
        {
            List<User> users = new List<Models.User>();

            using (var Context = new NoteAppContext())
            {
                users = Context.Users.ToList();
            }

            return View(users);
        }

        [HttpGet]
        public ActionResult AddUser(int ID = 0)
        {
            User user = new User();
            using (var Context = new NoteAppContext())
            {
                Context.Users.ToList();
                if (ID != 0)
                {
                    user = Context.Users.Where(x => x.ID == user.ID).FirstOrDefault();
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(User user)
        {
            using(var Context = new NoteAppContext())
            {
                if (user.ID == 0)
                {
                    Context.Users.Add(user);
                }
                else
                {
                    var us = Context.Users.Where(x => x.ID == user.ID).FirstOrDefault();
                    us.UserName = us.UserName;
                    us.Email = us.Email;
                    us.Password = us.Password;
                    us.ConfirmPassword = us.ConfirmPassword;
                }
                Context.SaveChanges();

            }
           
            return RedirectToAction("AddUser", "Account");
        }
        [HttpPost]
        public ActionResult DeleteUser(int ID)
        {using (var Context = new NoteAppContext())
            {
                var us = Context.Users.Where(x => x.ID == ID).FirstOrDefault();
                Context.Users.Remove(us);
                Context.SaveChanges();
            }
                return RedirectToAction("GetUserList", "Account");
        }

       
    }
}