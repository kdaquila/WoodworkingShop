using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoodworkingShop.Domain;
using WoodworkingShop.Domain.Entities;
using WoodworkingShop.Domain.Interfaces;
using WoodworkingShop.Infrastructure;
using WoodworkingShop.Infrastructure.QueryOptions;

namespace WoodworkingShop.WebMvc.ViewModels
{
    public class ProductViewModelService
    {
        public IRepository<Product> _products;

        public ProductViewModelService(IRepository<Product> products)
        {
            _products = products;
        }

        public async Task<List<ProductViewModel>> buildViewModel()
        {
            IQueryBuilder<Product> queryBuilder = _products.createQueryBuilder();
            queryBuilder.OrderBy = p => p.Name;

            IList<Product> productList = await _products.ListAsync(queryBuilder);
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
