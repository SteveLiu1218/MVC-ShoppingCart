﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartPractice.Models
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Amount {
            get {
                return this.Price * this.Quantity;
            }
        }
        public string DefaultImageURL { get; set; }

    }
}