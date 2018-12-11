using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingCartPractice.Models
{
    public class Ship
    {        
        [Required]
        [Display(Name ="收貨人名字")]
        [StringLength(30,ErrorMessage ="{0} 的長度必須至少為{2}字元",MinimumLength = 2)]
        public string RecieverName { get; set; }

        [Required]
        [Display(Name = "收貨人電話")]
        [StringLength(15, ErrorMessage = "{0} 的長度必須至少為{2}字元", MinimumLength = 8)]
        public string RecieverPhone { get; set; }

        [Required]
        [Display(Name = "收貨人地址")]
        [StringLength(256, ErrorMessage = "{0} 的長度必須至少為{2}字元", MinimumLength = 8)]
        public string RecieverAddress { get; set; }

    }
}