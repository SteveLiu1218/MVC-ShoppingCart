using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCartPractice.Controllers
{
    public class ProductListController : Controller
    {
        //Models.CartsEntities db = new Models.CartsEntities();
        // GET: ProductList
        public ActionResult Index()
        {
            List<Models.Carts> result = new List<Models.Carts>();
            
            using (Models.CartsEntities db = new Models.CartsEntities())
            {
                result = db.Carts.Select(c => c).ToList();
            }

            var productLists = Models.ProductLists.GetProductLists();
            return View(result);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.Carts productList)
        {
            using (Models.CartsEntities db = new Models.CartsEntities())
            {
                db.Carts.Add(productList);
                db.SaveChanges();
            }
            return View();
        }
    }
}