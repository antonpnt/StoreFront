using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreFront.Data
{
    public class OrderRepository
    {
        StoreFront.Data.ecommerceEntities db = new StoreFront.Data.ecommerceEntities();

        public Order GetOrder(int id)
        {
            Order order = db.Orders.Where(a => a.OrderID == id).FirstOrDefault();
            return order;
        }

        public List<Order> GetAllOrders()
        {
             List<Order> orders = db.Orders.ToList();

            return orders;
        }

        public List<Order> GetOrdersByDate(DateTime startDate, DateTime endDate)
        {

            List<Order> orders = db.Orders.Where(a => a.OrderDate >= startDate && a.OrderDate <= endDate).ToList();

            return orders;
        }

        public string MarkOrderAsShipped(int id)
        {
            var order = GetOrder(id);

            var status = order.Status.StatusID;
            status = 459;
            
            db.SaveChanges();

            return "Order " + order.OrderID + " is marked as shipped";

        }

     }
}
