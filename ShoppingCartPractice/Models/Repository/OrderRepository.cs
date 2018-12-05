using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartPractice.Models.Repository
{
    public class OrderRepository
    {
        public readonly CartsEntities db;
        public OrderRepository()
        {
            db = new CartsEntities();
        }
        public void CreateOrder(Order order)
        {
            db.Order.Add(order);
            db.SaveChanges();
        }
        public void CreateOrderDetails(Cart cart,int orderId)
        {
            List<OrderDetails> result = new List<OrderDetails>();
            foreach (var CartItem in cart)
            {
                result.Add(new OrderDetails()
                {
                    OrderId = orderId,
                    Name = CartItem.Name,
                    Price = CartItem.Price,
                    Quantity = CartItem.Quantity                    
                });
            }
            db.OrderDetails.AddRange(result);
            db.SaveChanges();
        }
    }
}