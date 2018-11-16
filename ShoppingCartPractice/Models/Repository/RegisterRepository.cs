using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingCartPractice.Models.ViewModel;

namespace ShoppingCartPractice.Models.Repository
{
    public class RegisterRepository
    {
        public readonly CartsEntities db;
        public RegisterRepository()
        {
            db = new CartsEntities();
        }
        public void Create(RegisterViewModel registerViewModel)
        {
            db.Users.Add(new Users()
            {
                Id = Guid.NewGuid(),
                Email = registerViewModel.Email,
                Password = registerViewModel.Password,
                ConfirmPassword = registerViewModel.Password
            });
            db.SaveChanges();
        }
    }
}