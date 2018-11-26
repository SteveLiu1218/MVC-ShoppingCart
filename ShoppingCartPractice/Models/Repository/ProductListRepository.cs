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
            db.Products.Add(new Products()
            {
                Id = Guid.NewGuid(),
                Name = productListViewModel.Name,
                Price = productListViewModel.Price,
                DefaultImageId = productListViewModel.DefaultImageId,
                PublishDate = productListViewModel.PublishDate,
                Quantity = productListViewModel.Quantity,
                CategoryId = productListViewModel.CategoryId,
                Description = productListViewModel.Description,
                DefaultImageURL = productListViewModel.DefaultImageURL
                
            });
            db.SaveChanges();
        }
        public void Update(Products products)
        {
            var result = (from s in db.Products
                          where s.Id == products.Id
                          select s).FirstOrDefault();

            result.Id = products.Id;
            result.Name = products.Name;
            result.Price = products.Price;
            result.DefaultImageId = products.DefaultImageId;
            result.PublishDate = products.PublishDate;
            result.Quantity = products.Quantity;
            result.CategoryId = products.CategoryId;
            result.Description = products.Description;
            result.DefaultImageURL = products.DefaultImageURL;
            db.SaveChanges();
        }
        public void Delete(Products products)
        {
            if (products != default(Models.Products))
            {
                db.Entry(products).State = System.Data.Entity.EntityState.Deleted;
                db.Products.Remove(products);
                db.SaveChanges();
            }
        }
    }
}