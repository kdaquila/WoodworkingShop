using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoodworkingShop.Domain;

namespace WoodworkingShop.WebMvc
{
    public class CartViewModel
    {
        public List<CartItemSetViewModel> ItemSets { get; set; }

        public CartViewModel()
        {
            ItemSets = new List<CartItemSetViewModel>();
        }
    }
}
