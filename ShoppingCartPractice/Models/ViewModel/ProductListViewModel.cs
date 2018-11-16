using System;
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
        [Display(Name="商品名稱")]
        public string Name { get; set; }

        [Required(ErrorMessage = "請填寫商品價格")]
        [Display(Name="商品價格")]
        public int Price { get; set; }

        [Required(ErrorMessage = "請填寫商品描述")]
        [Display(Name = "商品描述")]
        public string Description { get; set; }

        [Required(ErrorMessage = "請填寫商品群組編號")]
        [Display(Name = "商品群組編號")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "請填寫建立日期")]
        [Display(Name = "商品建立日期")]
        public DateTime PublishDate { get; set; }

        [Required(ErrorMessage = "請填寫商品圖案編碼")]
        [Display(Name = "商品圖案編碼")]
        public int DefaultImageId { get; set; }

        [Required(ErrorMessage = "請填寫商品數量")]
        [Display(Name = "商品數量")]
        public int Quantity { get; set; }
    }
    
}