using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingCartPractice.Models;
using ShoppingCartPractice.Models.Repository;
using ShoppingCartPractice.Models.ViewModel;

namespace ShoppingCartPractice.Service
{
    public class ProductListService
    {
        private readonly ProductListRepository cartsRepository;

        public ProductListService()
        {
            cartsRepository = new ProductListRepository();
        }

        public IEnumerable<Products> GetAll()
        {
            return cartsRepository.db.Products.ToList();
        }

        public IEnumerable<ProductListViewModel> GetViewModelData()
        {
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
                                 Quantity = item.Quantity,                                 
                                 DefaultImageURL = item.DefaultImageURL
                             };
            return resultData;
        }
    }
}