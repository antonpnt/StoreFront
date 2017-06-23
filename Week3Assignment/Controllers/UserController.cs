using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Week3Assignment.Models;

namespace Week3Assignment.Controllers
{
    public class UserController : Controller
    {
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
                //Does email already exist
                var exists = DoesEmailExist(user.EmailAddress);
                if (exists)
                {
                    ModelState.AddModelError("EmailExist", "Email already exists");
                    return View(user);
                }

                user.Password = Crypto.Hash(user.Password);
                user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword);

                using (ecommerceEntities db = new ecommerceEntities())
                {
                    //creates a shoppingcart for every user
                    ShoppingCart userCart = new ShoppingCart();
                    userCart.UserID = user.UserID;
                    userCart.CreatedBy = user.UserName;
                    userCart.DateCreated = System.DateTime.Today;
                    db.ShoppingCarts.Add(userCart);
                    db.Users.Add(user);
                    db.SaveChanges();
                    message = "Registration successfully done";
                    Status = true;
                }
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
            string message = "";
            using (ecommerceEntities db = new ecommerceEntities())
            {
                var v = db.Users.Where(a => a.UserName == login.UserName).FirstOrDefault();
                if (v != null)
                {
                    if (string.Compare(Crypto.Hash(login.Password), v.Password) == 0)
                    {
                        int timeout = login.RememberMe ? 525600 : 20;
                        var ticket = new FormsAuthenticationTicket(login.UserName, login.RememberMe, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);

                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        message = "User name and/or password was incorrect";
                    }

                }
                else
                {
                    message = "Invalid credential provided";
                }
            }

            ViewBag.message = message;
            return View();
        }


        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }

        [NonAction]
        public bool DoesEmailExist(string emailAddress)
        {
            using (ecommerceEntities db = new ecommerceEntities())
            {
                var v = db.Users.Where(a => a.EmailAddress == emailAddress).FirstOrDefault();
                return v != null;
            }
        }
    }

}