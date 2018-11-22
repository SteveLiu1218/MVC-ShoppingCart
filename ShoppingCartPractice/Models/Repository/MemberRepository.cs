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
        public void Update(MemberListViewModel memberListViewModel)
        {
            var userResult =  (from s in db.Users.ToList()
                              where s.Id == memberListViewModel.Id
                             select s).FirstOrDefault();
            if (userResult != null)
            {                
                userResult.UsrName = memberListViewModel.UsrName;
                userResult.Password = memberListViewModel.Password;
                userResult.ConfirmPassword = memberListViewModel.ConfirmPassword;
                db.SaveChanges();
            }                                      
        }
        public void Delete(Users users)
        {
            if (users != default(Models.Users))
            {
                db.Entry(users).State = System.Data.Entity.EntityState.Deleted;
                db.Users.Remove(users);
                db.SaveChanges();
            }
        }
    }
}