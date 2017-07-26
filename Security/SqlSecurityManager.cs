using StoreFront.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Security
{
    public class SqlSecurityManager
    {
        ecommerceEntities db = new ecommerceEntities();

        public Boolean AuthenticateUser(string username, string password)
        {
            return false;
        }

        public Boolean IsAdmin()
        {
            return false;
        }

        public User LoadUser(string username)
        {
            return null;
        }

        public void SaveUser()
        {
            db.SaveChanges();
        }

        public void RegisterUser()
        {

        }

        public void DeleteUser(string username)
        {

        }
    }
    
}