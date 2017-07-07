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
    }
}
