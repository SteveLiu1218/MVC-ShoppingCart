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
        private MemberRepository memberRepository;
        private AccountService accountService;
        public AccountController()
        {
            memberRepository = new MemberRepository();
            accountService = new AccountService();
        }
        //// GET: Account
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult ManageMember()
        {
            IEnumerable<ManageMemberViewModel> manageMemberViewModel = new List<ManageMemberViewModel>();
            manageMemberViewModel = accountService.GetManageMemberViewModels().ToList();
            return View(manageMemberViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManageMember(ManageMemberViewModel managerMemberViewModel)
        {
            if (ModelState.IsValid)
            {
                memberRepository.Update(managerMemberViewModel);
                return RedirectToAction("ManageMember", "Account");
            }
            return View(managerMemberViewModel);
        }

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
                memberRepository.Create(registerViewModel);
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