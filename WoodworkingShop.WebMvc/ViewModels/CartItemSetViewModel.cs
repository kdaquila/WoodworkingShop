using System;
using WoodworkingShop.Domain;

namespace WoodworkingShop.WebMvc
{
    public class CartItemSetViewModel
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }

        public CartItemSetViewModel(Guid productId, string name, int quantity)
        {
            ProductId = productId;
            ProductName = name;
            Quantity = quantity;
        }
    }
}
