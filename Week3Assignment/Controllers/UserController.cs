using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Week3Assignment.ViewModels;
using StoreFront.Data;

namespace Week3Assignment.Controllers
{
    public class UserController : Controller
    {
        ecommerceEntities db = new ecommerceEntities();
        SqlSecurityManager mgr = new SqlSecurityManager();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        //Registration Action
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        //Registration POST Action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind(Exclude = "IsAdmin,DateCreated,CreatedBy,DateModified,ModifiedBy")] User user)
        {
            bool Status = false;
            string message = "";

            //Model Validation
            if (ModelState.IsValid)
            {
                mgr.RegisterUser(user);

                ModelState.Clear();
                message = "Registration successfully done";
                Status = true;
                
            }
            else
            {
                message = "Invalid Request";
            }

            ViewBag.Message = message;
            ViewBag.Status = Status;
            return View(user);
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
             
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin login, string ReturnUrl)
        {
            string username = login.UserName;
            string password = login.Password;

            var v = mgr.AuthenticateUser(username, password);

            if (v)
            {
                int timeout = login.RememberMe ? 525600 : 20;
                var ticket = new FormsAuthenticationTicket(username, login.RememberMe, timeout);
                string encrypted = FormsAuthentication.Encrypt(ticket);
                FormsAuthentication.SetAuthCookie(login.UserName, false);

                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                cookie.Expires = DateTime.Now.AddMinutes(timeout);
                cookie.HttpOnly = true;
                Response.Cookies.Add(cookie);

                var user = db.Users.Where(a => a.UserName == username).FirstOrDefault();
                Session["Username"] = user.UserName;
                Session["UserID"] = user.UserID;
                if (user.IsAdmin == true)
                {
                    Session["IsAdmin"] = true;
                }
                else
                {
                    Session["IsAdmin"] = false;
                }
                    return RedirectToAction("Index", "Home");
                
            }

            else
            {
                ModelState.AddModelError("incorrect","User name and/or password was incorrect");
            }
            return View();
        }



        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login", "User");
        }

        [NonAction]
        public bool DoesEmailExist(string emailAddress)
        {
                var v = db.Users.Where(a => a.EmailAddress == emailAddress).FirstOrDefault();
                return v != null;
            
        }
    }

}