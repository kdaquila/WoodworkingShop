﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoodworkingShop.Domain;
using WoodworkingShop.Domain.Entities;
using WoodworkingShop.Domain.Interfaces;
using WoodworkingShop.Infrastructure;

namespace WoodworkingShop.WebMvc.ViewModels
{
    public class ProductViewModelService
    {
        private IRepository<Product> _products;

        public ProductViewModelService(IRepository<Product> products)
        {
            _products = products;
        }

        public async Task<List<ProductViewModel>> getProductViewModels()
        {
            IList<Product> productList = await _products.ListAsync(
                new SimpleQueryOptions<Product>
                {
                    Where = p => p.Name.StartsWith("T")
                }
            );
            List<ProductViewModel> productViewModels = new List<ProductViewModel>();
            foreach (Product product in productList)
            {
                productViewModels.Add(new ProductViewModel(
                    id: product.Id, 
                    name: product.Name, 
                    description: product.Description, 
                    price: product.Price));
            }
            return productViewModels;
        }
    }
}
