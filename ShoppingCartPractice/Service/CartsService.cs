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
        public void Update()
        {
            db.SaveChanges();
        }
        public void Delete()
        {
            db.SaveChanges();
        }
        
    }
}