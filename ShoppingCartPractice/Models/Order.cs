using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartPractice.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string RecieverName { get; set; }
        public string RecieverPhone { get; set; }
        public string RecieverAddress { get; set; }       
    }
}