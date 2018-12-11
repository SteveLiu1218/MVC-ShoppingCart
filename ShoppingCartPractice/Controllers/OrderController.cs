using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCartPractice.Models;
using ShoppingCartPractice.Models.Repository;
using ShoppingCartPractice.Service;

namespace ShoppingCartPractice.Controllers
{
    public class OrderController : Controller
    {
        private OrderRepository orderRepository;
        private AccountService accountService;
        // GET: Order
        public OrderController()
        {
            orderRepository = new OrderRepository();
            accountService = new AccountService();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Ship ship)
        {
            if (ModelState.IsValid)
            {
                var currentCart = Service.OperationService.GetCurrentCart();
                var order = new Order()
                {
                    UserId = (Guid)Session["LoginUsrId"],
                    RecieverName = ship.RecieverName,
                    RecieverPhone = ship.RecieverPhone,
                    RecieverAddress = ship.RecieverAddress
                };
                orderRepository.CreateOrder(order);
                orderRepository.CreateOrderDetails(currentCart,order.Id);
                return Content("訂購成功");
            }
            return View();
        }
        
    }
}