using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreFront.Data;
using System.Linq;
using Week3Assignment.Controllers;
using System.Web.Mvc;
using System.Web.Security;
using Week3Assignment;
using StoreFront.ShippingAPI;

//Class holding unit tests for the application
namespace StoreFront.UnitTest
{

    [TestClass]
    public class StoreFrontTest
    {
        ecommerceEntities db = new ecommerceEntities();

        //Test for user registration in UserController 
        [TestMethod]
        public void TestRegisterUser()
        {
            //Arrange
            var userController = new UserController();
            string userName = "usertest";
            string password = "test";
            string email = "user@test.com";
            DateTime date = System.DateTime.Now;
            string createdBy = "tester";

            User user = new User();
            user.UserName = userName;
            user.Password = password;
            user.ConfirmPassword = password;
            user.EmailAddress = email;
            user.DateCreated = date;
            user.CreatedBy = createdBy;

            //Act
            var result = userController.Registration(user) as ViewResult;
            var actUser = (User)result.ViewData.Model;

            //Assert
            Assert.IsNotNull(actUser);
            Assert.AreEqual(userName, actUser.UserName);
        }

        [TestMethod]
        public void TestLogout()
        {
            //Arrange
            var controller = new UserController();
            
            //Act
            RedirectResult result = (RedirectResult)controller.Logout();
            
            //result.RouteValues["action"].Equals("Login");
            //result.RouteValues["controller"].Equals("User");

            //Assert
            Assert.AreEqual(result.Url, "/User/Login");
            

        }

        //Tests to see if email already exists in DB in user controller
        [TestMethod]
        public void TestEmailAlreadyExists()
        {
            //Arrange
            var controller = new UserController();
            string email = "user@test.com";

            //Act
            var result = controller.DoesEmailExist(email);

            //Assert
            Assert.IsNotNull(result);

        }

        //Test for adding items to cart 
        [TestMethod]
        public void TestAddToCart()
        {
            //Arrange
            var controller = new ShoppingCartController();
            string prodName = "test product";
            string description = "test description";
            int quantity = 4;
            double price = 5.00;

            
            Product product = new Product();
            product.ProductName = prodName;
            product.Description = description;
            product.Quantity = quantity;
            product.Price = (decimal?)price;

            //Act
            var result = controller.AddToCart(product) as ViewResult;
            var prod = (Product)result.ViewData.Model;

            //Assert
            Assert.IsNotNull(prod);
        }


        //Get product list for the search controller
        [TestMethod]
        public void TestGetProducts()
        {
            //Arrange
            var products = db.Products.ToList();

            //Assert
            Assert.IsNotNull(products);

        }


        //Mark order as shipped in order controller in shipping API
        [TestMethod]
        public void TestMarkOrderShipped()
        {
            //Arrange
            var controller = new StoreFront.ShippingAPI.Controllers.OrderAPIController();
            int orderID = 210;

            //Act
            var result = controller.MarkOrderShipped(orderID);
            

            //Assert
            Assert.IsNotNull(result);
            

        }

        //Tests get orders method from shipping api order controller
        [TestMethod]
        public void TestGetOrdersFromShippingAPIOrderController()
        {
            //Arrange
            var controller = new ShippingAPI.Controllers.OrderAPIController();
            DateTime startDate = new DateTime(2017,7,10);
            DateTime endDate = new DateTime(2017, 7, 12);

            //Act
            var result = controller.GetOrders(startDate, endDate);

            //Assert
            Assert.IsNotNull(result);
            
        }

        //Get all orders for order controller
        [TestMethod]
        public void TestGetOrders()
        {
            //Arrange
            var orders = db.Orders.ToList();

            //Assert
            Assert.IsNotNull(orders);

        }

        //Test get details of a specific order
        [TestMethod]
        public void TestGetOrderDetails()
        {
            //Arrange
            var controller = new Week3Assignment.Controllers.OrderController();
            int orderID = 210;

            //Act
            var result = controller.Details(orderID);

            //Assert
            Assert.IsNotNull(result);
            
        }

        //Tests get the shopping cart products of a specific user
        [TestMethod]
        public void TestGetShoppingCartProducts()
        {
            //Arrange
            User user = db.Users.Where(a => a.UserName == "antonpinto").FirstOrDefault();
            ShoppingCart cart = db.ShoppingCarts.Where(a => a.UserID == user.UserID).FirstOrDefault();
  
            var list = db.ShoppingCartProducts.Where(a => a.ShoppingCartID == cart.ShoppingCartID).ToList();

            //Assert
            Assert.IsNotNull(list);
        }
        
        //Tests search products method in the inventory repository class
        [TestMethod]
        public void TestSearchProducts_InventoryRepository()
        {
            //Arrange
            InventoryRepository repos = new InventoryRepository();
            string searchText = "Skin";
      
            //Act
            Product result = repos.SearchProducts(searchText).FirstOrDefault();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(searchText, result.ProductName);
            
        }

        //Tests that there are no results that are shown when a product not in the database is searched for
        [TestMethod]
        public void TestSearchProductsFailure_InventoryRepository()
        {
            //Arrange
            InventoryRepository repos = new InventoryRepository();
            string searchText = "nonexistent";

            //Act
            var result = repos.SearchProducts(searchText);

            //Assert
            Assert.AreEqual(result.Count, 0);
        }

        //Tests the get product method of the inventory repository class
        [TestMethod]
        public void TestGetProduct_InventoryRepository()
        {
            //Arrange
            InventoryRepository repos = new InventoryRepository();
            int id = 1121;
            
            //Act
            Product result = repos.GetProduct(id);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.ProductID);

        }

        //Tests get order by a certain ID in the order repository class
        [TestMethod]
        public void TestGetOrder_OrderRepository()
        {
            //Arrange
            OrderRepository repos = new OrderRepository();
            int id = 210;

            //Act
            Order result = repos.GetOrder(id);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.OrderID);
        }

        //Tests load user method in the sql security manager class
        [TestMethod]
        public void TestLoadUser_SqlSecurityManager()
        {
            //Arrange
            SqlSecurityManager mgr = new SqlSecurityManager();
            User testUser = db.Users.Where(a => a.UserID == 329).FirstOrDefault();

            //Act
            User user = mgr.LoadUser(testUser.UserName);

            //Assert
            Assert.IsNotNull(user);
            //Assert.AreEqual(testUser, user);
        }

        //Tests the delete user method in the sql security manager class
        //Creates a dummy user, registers it, and then deletes it
        [TestMethod]
        public void TestDeleteUser_SqlSecurityManager()
        {
            //Arrange
            var userController = new UserController();
            SqlSecurityManager mgr = new SqlSecurityManager();
            User newUser = new User();
            newUser.UserName = "user test";
            newUser.Password = "userPW";
            newUser.ConfirmPassword = "userPW";
            newUser.EmailAddress = "email@email.com";

            //Act
            mgr.RegisterUser(newUser);
            User userToDelete = db.Users.Where(a => a.UserName == "user test").FirstOrDefault();
            mgr.DeleteUser(userToDelete.UserName);
            User userDeleted = db.Users.Where(a => a.UserName == "user test").FirstOrDefault();

            //Assert
            Assert.IsNull(userDeleted);
        }
    }
}
