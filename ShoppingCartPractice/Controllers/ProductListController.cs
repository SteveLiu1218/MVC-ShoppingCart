using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCartPractice.Models;
using ShoppingCartPractice.Models.ViewModel;
using ShoppingCartPractice.Service;

namespace ShoppingCartPractice.Controllers
{
    public class ProductListController : Controller
    {
        private readonly ProductListService productListService;
        //Models.CartsEntities db = new Models.CartsEntities();
        // GET: ProductList
        public ProductListController()
        {
            productListService = new ProductListService();
        }
        public ActionResult Index()
        {
            IEnumerable<ProductListViewModel> productListViewModel = new List<ProductListViewModel>();
            productListViewModel = productListService.GetViewModelData().ToList();
            return View(productListViewModel);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductListViewModel productListViewModel)
        {
            if (ModelState.IsValid)
            {
                productListService.Create(productListViewModel);
                return RedirectToAction("Index");
            }
            return View("Create", productListViewModel);
        }
    }
}