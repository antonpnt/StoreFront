using System.Data;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using StoreFront.Data;

namespace Week3Assignment.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        ecommerceEntities db = new ecommerceEntities();

        // GET: Search
        public ActionResult Index(string search, int? page)
        {
            //Takes in user input and returns the product that the user searched for, or the whole list of products if they did not enter anything
            return View(db.Products.Where(x => x.ProductName.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1,50));
        }

    }
}
