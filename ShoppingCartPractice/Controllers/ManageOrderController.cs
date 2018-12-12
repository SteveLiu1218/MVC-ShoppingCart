using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCartPractice.Service;
using ShoppingCartPractice.Models.ViewModel;
using ShoppingCartPractice.Models;

namespace ShoppingCartPractice.Controllers
{
    public class ManageOrderController : Controller
    {
        // GET: ManageOrder
        private ManageOrderService manageOrderService;
        public ManageOrderController()
        {
            manageOrderService = new ManageOrderService();
        }
        public ActionResult Index()
        {
            IEnumerable<ManageOrderViewModel> productListViewModel = new List<ManageOrderViewModel>();
            productListViewModel = manageOrderService.GetManageOrderViewModels().ToList();            
            return View(productListViewModel);            
        }

        public ActionResult Details(int id)
        {
            IEnumerable<OrderDetails> orderDetailsData = new List<OrderDetails>();
            orderDetailsData = manageOrderService.GetOrderDetails(id);
            return View(orderDetailsData);
        }
    }
}