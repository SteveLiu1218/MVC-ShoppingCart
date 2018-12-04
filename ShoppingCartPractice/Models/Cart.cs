using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace ShoppingCartPractice.Models
{
    public class Cart:IEnumerable<CartItem>
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.cartItems.GetEnumerator();
        }
        IEnumerator<CartItem> IEnumerable<CartItem>.GetEnumerator()
        {
            return this.cartItems.GetEnumerator();
        }

        private List<CartItem> cartItems;
        public Cart()
        {
            this.cartItems = new List<CartItem>();            
        }
        public int Count
        {
            get
            {
                return this.cartItems.Count;
            }
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

        public void AddProduct(Guid productId)
        {
            //先判斷相同Id的CartItem是否已經存在購物車內
            //如果有購物車數量+1
            var findItem = this.cartItems
                            .Where(s => s.Id == productId)
                            .Select(s => s)
                            .FirstOrDefault();            
            CartsEntities db = new CartsEntities();
            var product = (from s in db.Products
                           where s.Id == productId
                           select s).FirstOrDefault();
            if (product != default(Products))
            {
                this.AddProduct(product);
            }
            else
            {   //存在購物車內，則將商品數量累加
                findItem.Quantity += 1;
            }
        }
        //新增一筆Product，使用Product物件
        public void AddProduct(Products product)
        {
            //將Product轉為CartItem
            var cartItem = new CartItem()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = 1
            };
            //加進購物車
            this.cartItems.Add(cartItem);            
        }
        public void RemoveProduct(Guid id)
        {
            var findItem = this.cartItems
                           .Where(s => s.Id == id)
                           .Select(s => s).FirstOrDefault();
            if (findItem != null)
            {
                this.cartItems.Remove(findItem);
            }
        }
        public void ClearProduct()
        {
            this.cartItems.Clear();

        }
    }
}