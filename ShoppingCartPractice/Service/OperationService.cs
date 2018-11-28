using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ShoppingCartPractice.Models;

namespace ShoppingCartPractice.Service
{
    public class OperationService
    {
        [WebMethod(EnableSession = true)]
        public static Cart GetCurrentCart()
        {
            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Session["Cart"] == null)
                {                    
                    var order = new Cart();
                    HttpContext.Current.Session["Cart"] = order;
                }
                return (Cart)HttpContext.Current.Session["Cart"];
            }
            else
            {
                throw new InvalidOperationException("System HttpContext Current 為空 請檢查");
            }

        }
    }
}