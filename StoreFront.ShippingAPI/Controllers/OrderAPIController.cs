using StoreFront.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;


namespace StoreFront.ShippingAPI.Controllers
{
    public class OrderAPIController : ApiController
    {
        ecommerceEntities db = new ecommerceEntities();
        OrderRepository repos = new OrderRepository();
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //Not requirement for assignment, added for own reference
        //Gets all the orders in the order table
        public IEnumerable<Order> GetAllOrders()
        {
            List<Order> orders = db.Orders.ToList();

            return orders;
        }

        //Gets orders between the start date and the end date that the user enters
        [HttpGet]
        public List<Order> GetOrders(DateTime startDate, DateTime endDate)
        {

            List<Order> orders = db.Orders.Where(a => a.OrderDate >= startDate && a.OrderDate <= endDate).ToList();

            return orders;

        }

        //Marks the order id that the user enters as shipped
        [HttpGet]
        public string MarkOrderShipped(int id)
        {
            //Gets order using GetOrder() method from order repository
            var order = repos.GetOrder(id);

            var status = order.Status;
            status = db.Status.Where(a => a.StatusID == 459).FirstOrDefault();

            return "Order " + order.OrderID + " is marked as shipped";
        }



    }
}
