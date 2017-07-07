using System.Data;
using System.Linq;
using System.Web.Mvc;
using Week3Assignment.Models;
using PagedList;

namespace Week3Assignment.Controllers
{
    public class SearchController : Controller
    {
        //private ecommerceEntities db = new ecommerceEntities();
        StoreFront.Data.ecommerceEntities db = new StoreFront.Data.ecommerceEntities();

        // GET: Search
        public ActionResult Index(string search, int? page)
        {

            return View(db.Products.Where(x => x.ProductName.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1,50));
        }

    }
}
