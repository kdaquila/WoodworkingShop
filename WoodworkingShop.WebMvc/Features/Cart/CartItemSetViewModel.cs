using System;
using System.Collections.Generic;
using WoodworkingShop.Domain;

namespace WoodworkingShop.WebMvc
{
    public class CartItemSetViewModel
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public List<string> Categories { get; set; }

        public CartItemSetViewModel(Guid productId, string name, int quantity, List<string> category)
        {
            ProductId = productId;
            ProductName = name;
            Quantity = quantity;
            Categories = category;
        }
    }
}
