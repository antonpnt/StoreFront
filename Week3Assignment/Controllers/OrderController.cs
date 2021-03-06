﻿using StoreFront.Data;
using StoreFront.Data.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;

namespace Week3Assignment.Controllers
{
    public class OrderController : Controller
    {
        StoreFront.Data.ecommerceEntities db = new StoreFront.Data.ecommerceEntities();
        // GET: Order
        //Shows the list of orders
        public ActionResult Index(int? page)
        {
            return View(db.Orders.ToList().ToPagedList(page ?? 1,50));
        }

        //Shows the details of the order corresponding with a certain orderID
        public ActionResult Details(int id)
        {
            var userOrder = db.Orders.Where(a => a.OrderID == id).FirstOrDefault();

            return View(userOrder);
        }

        public PartialViewResult Products(Order order)
        {
            var orderID = order.OrderID;
            var list = db.OrderProducts.Where(a => a.OrderID == orderID).ToList();
            return PartialView("~/Views/Shared/_ProductInfo.cshtml", list);
        }
        
        //Removes a product from an order
        [HttpPost]
        public ActionResult RemoveFromOrder(int prodID)
        {
            OrderProduct product = db.OrderProducts.Where(a => a.OrderProductID == prodID).FirstOrDefault();
            db.OrderProducts.Remove(product);
            db.SaveChanges();
            
            return Json(new { prodID });
        }

        //Allows the user to enter a new quantity of a certain product 
        [HttpPost]
        public ActionResult UpdateOrder(int prodID, int updatedQuantity)
        {
            OrderProduct product = db.OrderProducts.Where(a => a.OrderProductID == prodID).FirstOrDefault();
            product.Quantity = updatedQuantity;
            db.SaveChanges();

            return Json(new { prodID, updatedQuantity });
        }


    }
}