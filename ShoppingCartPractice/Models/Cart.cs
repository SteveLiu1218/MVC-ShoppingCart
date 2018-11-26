using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartPractice.Models
{
    public class Cart
    {
        public List<CartItem> cartItems { get; set; }
        public Cart()
        {
            this.cartItems = new List<CartItem>();
        }
        public decimal TotalAmount {
            get
            {
                decimal totalAmount = 0.0m;
                foreach (var cartItem in this.cartItems)
                {
                    totalAmount = totalAmount + cartItem.Amount;
                }
                return totalAmount;
            }
        }
    }
}