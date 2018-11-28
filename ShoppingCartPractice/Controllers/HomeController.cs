using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCartPractice.Service;

namespace ShoppingCartPractice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductListService productListService;
        public HomeController()
        {
            productListService = new ProductListService();
        }
        public ActionResult Index()
        {
            var resultData = productListService.GetAll().ToList();
            return View(resultData);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult AddToCart(Guid id)
        {
            var cart = OperationService.GetCurrentCart();
            cart.AddProduct(id);
            return PartialView("_CartPartial");
        }
        //public ActionResult GetCart()
        //{
        //    var cart = Service.OperationService.GetCurrentCart();
        //    if (cart.cartItems.Count == 0)
        //    {
        //        cart.cartItems.Add(
        //            new Models.CartItem()
        //            {
        //                Id = 1,
        //                Name = "測試",
        //                Quantity = 1,
        //                Price = 100m
        //            }
        //            );
        //    }
        //    else
        //    {                
        //        cart.cartItems.First().Quantity += 1;
        //    }
        //    return Content(string.Format("目前購物車總共:{0}元", cart.TotalAmount));

        //}
    }
}