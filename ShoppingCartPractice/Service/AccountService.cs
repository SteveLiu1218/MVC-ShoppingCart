using ShoppingCartPractice.Models;
using ShoppingCartPractice.Models.Repository;
using ShoppingCartPractice.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartPractice.Service
{
    public class AccountService
    {
        private MemberRepository registerRepository;
        public AccountService()
        {
            registerRepository = new MemberRepository();
        }
        public IEnumerable<Users> GetUsers()
        {
            return registerRepository.db.Users.ToList();
        }
        public IEnumerable<MemberListViewModel> GetManageMemberViewModels()
        {
            var resultData = from item in GetUsers()
                             select new MemberListViewModel
                             {
                                 Id = item.Id,
                                 UsrName = item.UsrName,
                                 Password = item.Password
                             };
            return resultData;
        }
        public bool CheckAccountData(LoginViewModel loginViewModel,ref string UsrName)
        {
            var result = (from s in GetUsers()
                          where loginViewModel.Email == s.Email
                          select s).FirstOrDefault();
            if (result != null)
            {
                UsrName = result.UsrName;
                return true;
            }
            return false;
        }
    }
}