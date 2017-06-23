using System.Linq;
using System.Web.Mvc;
using Week3Assignment.Models;

namespace Week3Assignment.Controllers
{
    public class ShoppingCartController : Controller
    {
        ecommerceEntities db = new ecommerceEntities();

        //Shows the cart for the current user
        public ActionResult Index()
        {
            User user = db.Users.Where(a => a.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
            var userID = user.UserID;
            ShoppingCart cart = db.ShoppingCarts.Where(a => a.UserID == userID).FirstOrDefault();
            var shoppingCartID = cart.ShoppingCartID;
            var list = db.ShoppingCartProducts.Where(a => a.ShoppingCartID == shoppingCartID);

            return View(list.ToList());
        }

        //Adds an item to a cart
        public ActionResult AddToCart(Product prod)
        {
            //Gets the user ID and cart if there is a cart associated with that user
            User user = db.Users.Where(a => a.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
            var userID = user.UserID;
            var cart = db.ShoppingCarts.Where(a => a.UserID == userID).FirstOrDefault();

            //new shopping cart if there isn't one for that user and save the cart to the database
            if (cart == null)
            {
                ShoppingCart newCart = new ShoppingCart();
                newCart.UserID = userID;
                newCart.CreatedBy = user.UserName;
                newCart.DateCreated = System.DateTime.Today;

                db.ShoppingCarts.Add(newCart);
                db.SaveChanges();

            }
            //If there is already a cart for the user
            else
            {
                var shoppingCartID = cart.ShoppingCartID;
                var doesExist = DoesItemExist(shoppingCartID, prod.ProductID);

                //If the item does already exist, then just increase the quantity and save the changes to the database
                if (doesExist)
                {
                    var cartItem = db.ShoppingCartProducts.Where(a => a.ShoppingCartID == shoppingCartID).Where(a => a.ProductID == prod.ProductID).FirstOrDefault();
                    cartItem.Quantity += 1;
                    db.SaveChanges();
                }
                //If the item does not already exist, create a new item and add it into the shopping cart and save it to the database
                else
                {
                    ShoppingCartProduct newItem = new ShoppingCartProduct();
                    newItem.ShoppingCartID = shoppingCartID;
                    newItem.ProductID = prod.ProductID;
                    newItem.Quantity = 1;
                    db.ShoppingCartProducts.Add(newItem);
                    db.SaveChanges();
                }
            }
            //Reloads the search page
            return RedirectToAction("Index", "Search");
        }


        //Removes an item from a cart
        [HttpPost]
        public ActionResult RemoveFromCart(int prodID)
        {
            User user = db.Users.Where(a => a.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
            var userID = user.UserID;
            ShoppingCart cart = db.ShoppingCarts.Where(a => a.UserID == userID).FirstOrDefault();
            var cartItem = db.ShoppingCartProducts.Where(a => a.ShoppingCartProductID == prodID).FirstOrDefault();
            db.ShoppingCartProducts.Remove(cartItem);
            db.SaveChanges();
            decimal? total = db.ShoppingCartProducts.Sum(a => a.Product.Price * a.Quantity) - 15; //fix this

            return Json(new { prodID, total });

        }

        [HttpPost]
        public ActionResult UpdateCart(int prodID, int updatedQuantity)
        {
            User user = db.Users.Where(a => a.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
            var userID = user.UserID;
            ShoppingCart cart = db.ShoppingCarts.Where(a => a.UserID == userID).FirstOrDefault();
            ShoppingCartProduct item = db.ShoppingCartProducts.Where(a => a.ProductID == prodID).FirstOrDefault();

            item.Quantity = updatedQuantity;

            db.SaveChanges();

            return Json( new { prodID, updatedQuantity});
        }


        //Checks to see if there is already an instance of an item in the users shopping cart
        [NonAction]
        public bool DoesItemExist(int cartID, int prodID)
        {

            var v = db.ShoppingCartProducts.Where(a => a.ShoppingCartID == cartID).Where(a => a.ProductID == prodID).FirstOrDefault();
            return v != null;

        }

    }
}