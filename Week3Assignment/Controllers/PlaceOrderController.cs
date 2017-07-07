using StoreFront.Data;
using StoreFront.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Week3Assignment.Controllers
{
    public class PlaceOrderController : Controller
    {
        StoreFront.Data.ecommerceEntities db = new StoreFront.Data.ecommerceEntities();
        // GET: PlaceOrder
        public ActionResult Index()
        {
            return View();
        }

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

        public ActionResult PlaceOrder()
        {
            User user = db.Users.Where(a => a.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
            var userID = user.UserID;
            var cart = db.ShoppingCarts.Where(a => a.UserID == userID).FirstOrDefault();
            var products = db.ShoppingCartProducts.Where(a => a.ShoppingCartID == cart.ShoppingCartID).ToList();
            Address address = db.Addresses.Where(a => a.UserID == userID).FirstOrDefault();
            var addressId = address.AddressID;
            decimal? total = products.Sum(a => a.Product.Price * a.Quantity);

            Order newOrder = new Order();
            newOrder.UserID = userID;
            newOrder.OrderDate = System.DateTime.Now;
            newOrder.Total = total;
            //add status here
            newOrder.DateCreated = System.DateTime.Today;
            newOrder.CreatedBy = user.UserName;
            newOrder.AddressID = addressId;
            db.Orders.Add(newOrder);
            db.SaveChanges();

            foreach (var item in products)
            {
                OrderProduct orderProd = new OrderProduct();
                orderProd.OrderID = newOrder.OrderID;
                orderProd.ProductID = item.ProductID;
                orderProd.Quantity = item.Quantity;
                orderProd.Price = item.Product.Price;
                orderProd.DateCreated = System.DateTime.Now;
                db.OrderProducts.Add(orderProd);
                db.SaveChanges();
            }
            return RedirectToAction("ConfirmOrder", "PlaceOrder");


        }

        public ActionResult ConfirmOrder()
        {


            return View();
        }

        public PartialViewResult Products(Order order)
        {
            var orderID = order.OrderID;
            var list = db.OrderProducts.Where(a => a.OrderID == orderID).ToList();
            return PartialView("~/Views/Shared/_ProductInfo.cshtml", list);
        }

        public ActionResult OrderSubmitted()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveAddress(Address address)
        {
            User user = db.Users.Where(a => a.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
            var userID = user.UserID;
            Order order = db.Orders.Where(a => a.UserID == userID).FirstOrDefault();

            address.UserID = userID;
            address.DateCreated = System.DateTime.Now;
            order.AddressID = address.AddressID;
            db.Addresses.Add(address);
            db.SaveChanges();

            return RedirectToAction("Address");
        }



    }
}