using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCartPractice.Controllers
{
    public class ProductListController : Controller
    {
        // GET: ProductList
        public ActionResult Index()
        {
            var productLists = Models.ProductLists.GetProductLists();
            return View(productLists);
        }
    }
}