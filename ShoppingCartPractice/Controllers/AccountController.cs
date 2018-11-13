using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCartPractice.Models;
using ShoppingCartPractice.Models.ViewModel;
using ShoppingCartPractice.Models.Repository;

namespace ShoppingCartPractice.Controllers
{
    public class AccountController : Controller
    {
        private RegisterRepository registerRepository;
        public AccountController()
        {
            registerRepository = new RegisterRepository();
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]        
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                registerRepository.Create(registerViewModel);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Login()
        {
            
            return View();
        }
    }
}