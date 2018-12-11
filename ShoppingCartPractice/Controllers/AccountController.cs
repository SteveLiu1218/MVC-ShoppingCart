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

        public ActionResult MemberList()
        {
            IEnumerable<MemberListViewModel> memberListViewModel = new List<MemberListViewModel>();
            memberListViewModel = accountService.GetManageMemberViewModels().ToList();
            return View(memberListViewModel);
        }
        public ActionResult EditMember(Guid id)
        {
            var result = (from s in accountService.GetUsers()
                          where s.Id == id
                          select new MemberListViewModel()
                          {
                              Id = s.Id,                              
                              Password = s.Password,
                              ConfirmPassword = s.ConfirmPassword,
                              UsrName = s.UsrName
                          }).FirstOrDefault();
            if (result == null)
            {
                RedirectToAction("MemberList");
            }
            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMember(MemberListViewModel memberListViewModel)
        {
            if (ModelState.IsValid)
            {
                memberRepository.Update(memberListViewModel);
                return RedirectToAction("MemberList", "Account");
            }
            return View(memberListViewModel);
        }

        [HttpPost]
        public ActionResult DeleteMember(Guid id)
        {
            var result = (from s in accountService.GetUsers()
                          where s.Id == id
                          select s).FirstOrDefault();
            if (result == null)
            {
                return RedirectToAction("MemberList");
            }
            else
            {
                memberRepository.Delete(result);
                return RedirectToAction("MemberList");
            }
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
            Guid Id = new Guid();
            if (ModelState.IsValid)
            {
                if (accountService.CheckAccountData(loginViewModel,ref UsrName,ref Id))
                {                    
                    //登入成功
                    Session["LoginSuccess"] = "Success";
                    Session["LoginUsr"] = UsrName;
                    Session["LoginUsrId"] = Id;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(loginViewModel);
        }

        public ActionResult LogOff()
        {
            Session["LoginSuccess"] = "";
            Session["LoginUsr"] = "";
            Session["LoginUsrId"] = "";
            return RedirectToAction("Index", "Home");
        }
    }
}