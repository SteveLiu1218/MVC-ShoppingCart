using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartPractice.Models.ViewModel
{
    public class ManageOrderPartialClass
    {
    }
    public partial class ManageOrderViewModel
    {
        private readonly CartsEntities db;
        public ManageOrderViewModel()
        {
            db = new CartsEntities();
        }
        public string GetUsrName()
        {
            var result = (from s in db.Users
                          where s.Id == this.UserId
                          select s.UsrName).FirstOrDefault();
            return result;

        }
    }
}