using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreFront.Data
{
    public class InventoryRepository
    {
        ecommerceEntities db = new ecommerceEntities();

        public List<Product> SearchProducts(string text)
        {
            var products = db.Products.Where(a => a.ProductName.StartsWith(text) || a.Description.StartsWith(text)).ToList();

            return products;
        }

        public Product GetProduct(int id)
        {
            Product prod = db.Products.Where(a => a.ProductID == id).FirstOrDefault();
        
            return prod;

        }
    }
}
