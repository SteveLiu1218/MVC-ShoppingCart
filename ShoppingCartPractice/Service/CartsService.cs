using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingCartPractice.Models;
using ShoppingCartPractice.Models.ViewModel;

namespace ShoppingCartPractice.Service
{
    public class ProductListService
    {
        private readonly CartsEntities db;

        public ProductListService()
        {
            db = new CartsEntities();
        }

        public IEnumerable<Carts> GetAll()
        {
            return db.Carts.ToList();
        }

        public IEnumerable<ProductListViewModel> GetViewModelData()
        {
            var cartsService = new ProductListService();
            var resultData = from item in GetAll()
                             select new ProductListViewModel
                             {
                                 Id = item.Id,
                                 Name = item.Name,
                                 Price = item.Price,
                                 Description = item.Description,
                                 CategoryId = item.CategoryId,
                                 PublishDate = item.PublishDate,
                                 DefaultImageId = item.DefaultImageId,
                                 Quantity = item.Quantity
                             };
            return resultData;
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
            var result = (from s in GetAll()
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