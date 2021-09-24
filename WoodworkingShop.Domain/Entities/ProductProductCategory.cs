using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodworkingShop.Domain
{
    public class ProductProductCategory
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        
        public Guid ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }

        public ProductProductCategory(Guid productId, Guid productCategoryId)
        {
            ProductId = productId;
            ProductCategoryId = productCategoryId;
        }
    }
}
