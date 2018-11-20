using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingCartPractice.Models.ViewModel;

namespace ShoppingCartPractice.Models.Repository
{
    public class MemberRepository
    {
        public readonly CartsEntities db;
        public MemberRepository()
        {
            db = new CartsEntities();
        }
        public void Create(RegisterViewModel registerViewModel)
        {
            db.Users.Add(new Users()
            {
                Id = Guid.NewGuid(),
                UsrName = registerViewModel.UsrName,
                Email = registerViewModel.Email,
                Password = registerViewModel.Password,
                ConfirmPassword = registerViewModel.Password
            });
            db.SaveChanges();
        }
        public void Update(ManageMemberViewModel manageMemberViewModel)
        {
            var userResult =  (from s in db.Users.ToList()
                              where s.Id == manageMemberViewModel.Id
                             select s).FirstOrDefault();
            if (userResult != null)
            {
                userResult.Password = manageMemberViewModel.Password;
                userResult.UsrName = manageMemberViewModel.UsrName;                
            }
            db.SaveChanges();
                             
        }
    }
}