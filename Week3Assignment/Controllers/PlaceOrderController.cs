using StoreFront.Data;
using StoreFront.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Week3Assignment.Controllers
{
    [Authorize]
    public class PlaceOrderController : Controller
    {
        StoreFront.Data.ecommerceEntities db = new StoreFront.Data.ecommerceEntities();
        // GET: PlaceOrder
        public ActionResult Index()
        {
            return View();
        }

        //Sets up the drop down lists for the user addresses and list of states
        public ActionResult Address()
        {
            User user = db.Users.Where(a => a.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
            var userID = user.UserID;

            var getState = db.States.ToList();
            SelectList stateList = new SelectList(getState, "StateID", "StateName", "SelectedValue");
            ViewBag.stateList = stateList;

            var getAddress = db.Addresses.Where(a => a.UserID == userID).ToList();
            SelectList list = new SelectList(getAddress, "AddressID", "Address1", "SelectedValue");
            ViewBag.addressList = list;

            return View();
        }

        //Gets the address that the user selected
        public ActionResult GetSelected ([Bind(Include = "AddressID")]Address selected)
        {
            var selectedAdd = selected.AddressID;
            return RedirectToAction("PlaceOrder", "PlaceOrder", new { id = selectedAdd });

        }

        //Makes a new order, and adds the items in the shoppingCartProducts for that user to the orderproducts for that user
        public ActionResult PlaceOrder(int id)
        {
            User user = db.Users.Where(a => a.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
            var userID = user.UserID;
            var cart = db.ShoppingCarts.Where(a => a.UserID == userID).FirstOrDefault();
            var products = db.ShoppingCartProducts.Where(a => a.ShoppingCartID == cart.ShoppingCartID).ToList();
            decimal? total = products.Sum(a => a.Product.Price * a.Quantity);

            Order newOrder = new Order();
            newOrder.UserID = userID;
            newOrder.OrderDate = System.DateTime.Now;
            newOrder.Total = total;
            newOrder.StatusID = 457;
            newOrder.DateCreated = System.DateTime.Today;
            newOrder.CreatedBy = user.UserName;
            newOrder.AddressID = id;
            db.Orders.Add(newOrder);
            db.SaveChanges();

            foreach (var item in products)
            {
                //Creates new order product for each item
                OrderProduct orderProd = new OrderProduct();
                orderProd.OrderID = newOrder.OrderID;
                orderProd.ProductID = item.ProductID;
                orderProd.Quantity = item.Quantity;
                orderProd.Price = item.Product.Price;
                orderProd.DateCreated = System.DateTime.Now;
                orderProd.CreatedBy = user.UserName;
                db.OrderProducts.Add(orderProd);
                db.SaveChanges();
            }

            return RedirectToAction("ConfirmOrder", "PlaceOrder", new { addID = id });

        }

        //Displays address information, general information, and product information of the users order
        public ActionResult ConfirmOrder(int addID)
        {
            var userAddress = db.Orders.Where(a => a.AddressID == addID).FirstOrDefault();
            return View(userAddress);
        }

        public PartialViewResult Products(Order order)
        {
            var orderID = order.OrderID;
            var list = db.OrderProducts.Where(a => a.OrderID == orderID).ToList();
            return PartialView("~/Views/Shared/_ProductInfo.cshtml", list);
        }

        //Submits the order and then removes the products from the users shopping carts
        public ActionResult OrderSubmitted()
        {
            User user = db.Users.Where(a => a.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
            var userID = user.UserID;
            var cart = db.ShoppingCarts.Where(a => a.UserID == userID).FirstOrDefault();
            var products = db.ShoppingCartProducts.Where(a => a.ShoppingCartID == cart.ShoppingCartID).ToList();

            foreach(var item in products)
            {
                db.ShoppingCartProducts.Remove(item);
            }
            db.SaveChanges();

            return View();
        }

        //Form that allows the user to enter a new address
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveAddress(Address address)
        {
            User user = db.Users.Where(a => a.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
            var userID = user.UserID;
            Order order = db.Orders.Where(a => a.UserID == userID).FirstOrDefault();

            address.UserID = userID;
            address.DateCreated = System.DateTime.Now;
            address.Address1 = address.Address1;
            db.Addresses.Add(address);
            db.SaveChanges();

            return RedirectToAction("Address");
        }



    }
}