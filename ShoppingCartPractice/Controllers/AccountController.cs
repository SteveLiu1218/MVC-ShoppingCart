using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCartPractice.Models;
using ShoppingCartPractice.Models.ViewModel;
using ShoppingCartPractice.Models.Repository;
using ShoppingCartPractice.Service;

namespace ShoppingCartPractice.Controllers
{
    public class AccountController : Controller
    {
        private RegisterRepository registerRepository;
        private AccountService accountService;
        public AccountController()
        {
            registerRepository = new RegisterRepository();
            accountService = new AccountService();
        }
        //// GET: Account
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Register()
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
                return RedirectToAction("Index","Home");
            }
            return View(registerViewModel);
        }
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            string UsrName = "";
            if (ModelState.IsValid)
            {
                if (accountService.CheckAccountData(loginViewModel,ref UsrName))
                {
                    //登入成功
                    Session["LoginSuccess"] = "Success";
                    Session["LoginUsr"] = UsrName;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(loginViewModel);
        }

        public ActionResult LogOff()
        {
            Session["LoginSuccess"] = "";
            Session["LoginUsr"] = "";
            return RedirectToAction("Index", "Home");
        }
    }
}