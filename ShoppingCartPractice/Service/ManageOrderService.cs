using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingCartPractice.Models;
using ShoppingCartPractice.Models.ViewModel;

namespace ShoppingCartPractice.Service
{    
    public class ManageOrderService
    {
        private readonly CartsEntities db;
        public ManageOrderService()
        {
            db = new CartsEntities();
        }
        public IEnumerable<Order> GetOrder()
        {
            return db.Order.ToList();
        }
        public IEnumerable<ManageOrderViewModel> GetManageOrderViewModels()
        {
            var resultData = from item in GetOrder()
                             select new ManageOrderViewModel
                             {
                                 Id = item.Id,
                                 UserId = item.UserId,
                                 RecieverAddress = item.RecieverAddress,
                                 RecieverName = item.RecieverName,
                                 RecieverPhone = item.RecieverPhone
                             };
            return resultData;
        }
    }
}