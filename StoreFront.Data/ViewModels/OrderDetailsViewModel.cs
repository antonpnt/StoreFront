using System.Collections.Generic;


namespace StoreFront.Data.ViewModels
{
    public class OrderDetailsViewModel
    {

        public List<Order> Orders { get; set; }

        public List<Address> Addresses { get; set; }
        
        public List<ShoppingCartProduct> Products { get; set; }

        

    }
}
