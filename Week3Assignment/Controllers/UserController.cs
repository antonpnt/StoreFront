using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Week3Assignment.Models;
using StoreFront.Data;

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
        public ActionResult Registration([Bind(Exclude = "IsAdmin,DateCreated,CreatedBy,DateModified,ModifiedBy")] StoreFront.Data.User user)
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

                using (StoreFront.Data.ecommerceEntities db = new StoreFront.Data.ecommerceEntities())
                {
                    //creates a shoppingcart for every user
                    StoreFront.Data.ShoppingCart userCart = new StoreFront.Data.ShoppingCart();
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
            using (StoreFront.Data.ecommerceEntities db = new StoreFront.Data.ecommerceEntities())
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
            using (StoreFront.Data.ecommerceEntities db = new StoreFront.Data.ecommerceEntities())
            {
                var v = db.Users.Where(a => a.EmailAddress == emailAddress).FirstOrDefault();
                return v != null;
            }
        }
    }

}