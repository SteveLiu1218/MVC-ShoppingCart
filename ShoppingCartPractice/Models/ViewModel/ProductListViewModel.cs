﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ShoppingCartPractice.Service;
using ShoppingCartPractice.Models;
using ShoppingCartPractice.Models.ViewModel;
using System.ComponentModel;

namespace ShoppingCartPractice.Models.ViewModel
{
    public class ProductListViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "請填寫商品名稱")]
        [DisplayName("商品名稱")]
        public string Name { get; set; }

        [Required(ErrorMessage = "請填寫商品價格")]
        [DisplayName("商品價格")]
        public int Price { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public DateTime PublishDate { get; set; }

        public int DefaultImageId { get; set; }

        public int Quantity { get; set; }
    }
    
}