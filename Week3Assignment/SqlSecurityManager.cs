using StoreFront.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using System.Web.UI;
using Week3Assignment.Controllers;

namespace Week3Assignment
{
    public class SqlSecurityManager : Page
    {
        ecommerceEntities db = new ecommerceEntities();

        //Returns a true or false boolean value depending on whether the username and password are valid
        public bool AuthenticateUser(string username, string password)
        {
            var user = db.Users.Where(a => a.UserName == username).FirstOrDefault();

            if (user != null)
            {
                if (string.Compare(Crypto.Hash(password), user.Password) == 0)
                {
                    if(Session != null)
                    {
                        Session["Username"] = username;
                    }
                    
                    return true;
                }
            }
            return false;
        }

        //Returns true or false if the username stored in the session is an admin 
        public bool IsAdmin(string username)
        {
            User user = db.Users.Where(a => a.UserName == username).FirstOrDefault();

            if(user.IsAdmin == true)
            {
                return true;
            }

            return false;
        }

        //Loads the properties of the username that is passed to the method
        public User LoadUser(string username)
        {
            User user = db.Users.Where(a => a.UserName == username).FirstOrDefault();
            return user;
        }

        //Updates the database to save the user 
        public void SaveUser()
        {
            db.SaveChanges();
        }

        //Allows the user to create an account and also adds a shopping cart for that user
        public void RegisterUser(User user)
        {
            UserController controller = new UserController();
            var exists = controller.DoesEmailExist(user.EmailAddress);
            if (!exists)
            {
                user.Password = Crypto.Hash(user.Password);
                user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword);
                user.IsAdmin = false;
                user.CreatedBy = user.UserName;
                user.DateCreated = System.DateTime.Now;

                ShoppingCart userCart = new ShoppingCart();
                userCart.UserID = user.UserID;
                userCart.CreatedBy = user.UserName;
                userCart.DateCreated = System.DateTime.Today;

                db.ShoppingCarts.Add(userCart);
                db.Users.Add(user);
                SaveUser();
            }
            else
            {
                ModelState.AddModelError("EmailExist", "Email already exists");
            }

        }

        //Removes the user from the database
        public void DeleteUser(string username)
        {
            User user = db.Users.Where(a => a.UserName == username).FirstOrDefault();
            ShoppingCart userCart = db.ShoppingCarts.Where(a => a.UserID == user.UserID).FirstOrDefault();
            db.ShoppingCarts.Remove(userCart);
            db.Users.Remove(user);
            db.SaveChanges();

        }
    }
}