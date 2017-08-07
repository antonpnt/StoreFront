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
            List<Order> orders = repos.GetAllOrders();

            return orders;
        }

        //Gets orders between the start date and the end date that the user enters
        [HttpGet]
        public List<Order> GetOrders(DateTime startDate, DateTime endDate)
        {

            List<Order> orders = repos.GetOrdersByDate(startDate, endDate);

            return orders;

        }

        //Marks the order id that the user enters as shipped
        [HttpGet]
        public string MarkOrderShipped(int id)
        {
            var order = repos.MarkOrderAsShipped(id);
            
            return order;
        }



    }
}
