﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreFront.Data
{
    public class InventoryRepository
    {
        StoreFront.Data.ecommerceEntities db = new StoreFront.Data.ecommerceEntities();

        public List<Product> SearchProducts(string searchText)
        {
            return null;
        }

        public Product GetProduct(int id)
        {
            Product prod = db.Products.Where(a => a.ProductID == id).FirstOrDefault();
            return prod;
            
        }
    }
}
