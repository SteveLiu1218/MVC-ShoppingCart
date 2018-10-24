using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartPractice.Models
{
    public class ProductLists
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public static List<ProductLists> GetProductLists()
        {
            List<ProductLists> productList = new List<ProductLists>();
            productList.Add(new ProductLists {
                Id = 1 ,
                Name = "鉛筆",
                Price = 10.0m
            });
            productList.Add(new ProductLists
            {
                Id = 2,
                Name = "原子筆",
                Price = 20.0m
            });

            return productList;
        }
    }
}