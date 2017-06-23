using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Week3Assignment.Models;

namespace Week3Assignment.ViewModels
{
    public class ShoppingCartViewModel : CustomerBaseViewModel
    {
        public List<ShoppingCart> ShoppingCartItems { get; set; }
        public decimal CartTotal { get; set; }

    }
}