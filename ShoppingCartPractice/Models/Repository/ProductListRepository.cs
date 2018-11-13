using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingCartPractice.Models.ViewModel;
using ShoppingCartPractice.Service;

namespace ShoppingCartPractice.Models.Repository
{
    public class ProductListRepository
    {
        public readonly CartsEntities db;

        public ProductListRepository()
        {
            db = new CartsEntities();
        }

        public void Create(ProductListViewModel productListViewModel)
        {
            db.Carts.Add(new Carts()
            {
                Id = Guid.NewGuid(),
                Name = productListViewModel.Name,
                Price = productListViewModel.Price,
                DefaultImageId = productListViewModel.DefaultImageId,
                PublishDate = productListViewModel.PublishDate,
                Quantity = productListViewModel.Quantity,
                CategoryId = productListViewModel.CategoryId,
                Description = productListViewModel.Description
            });
            db.SaveChanges();
        }
        public void Update(Carts carts)
        {
            var result = (from s in db.Carts
                          where s.Id == carts.Id
                          select s).FirstOrDefault();

            result.Id = carts.Id;
            result.Name = carts.Name;
            result.Price = carts.Price;
            result.DefaultImageId = carts.DefaultImageId;
            result.PublishDate = carts.PublishDate;
            result.Quantity = carts.Quantity;
            result.CategoryId = carts.CategoryId;
            result.Description = carts.Description;
            db.SaveChanges();
        }
        public void Delete(Carts carts)
        {
            db.Carts.Remove(carts);
            db.SaveChanges();
        }
    }
}