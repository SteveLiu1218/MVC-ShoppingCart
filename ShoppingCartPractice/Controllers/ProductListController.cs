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
        private readonly IEnumerable<Carts> cartsData;
        public ProductListController()
        {
            productListService = new ProductListService();
            cartsData = productListService.GetAll();
        }
        public ActionResult Index()
        {
            IEnumerable<ProductListViewModel> productListViewModel = new List<ProductListViewModel>();
            productListViewModel = productListService.GetViewModelData().ToList();
            ViewBag.ResultMessage = TempData["ResultMessage"];
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
                TempData["ResultMessage"] = string.Format("商品 [{0}] 建立成功", productListViewModel.Name);
                return RedirectToAction("Index");
            }
            return View("Create", productListViewModel);
        }

        public ActionResult Edit(Guid id)
        {
            var result = (from s in cartsData
                          where s.Id == id
                          select s).FirstOrDefault();
            if (result == null)
            {
                TempData["ResultMessage"] = "資料有誤，請重新操作";
                return RedirectToAction("Index");
            }
            return View(result);                        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductListViewModel productListViewModel)
        {
            if (ModelState.IsValid)
            {
                productListService.Update(productListViewModel);
                return RedirectToAction("Index");
            }
            return View(productListViewModel);
        }
    }
}