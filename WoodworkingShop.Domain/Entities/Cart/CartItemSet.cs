using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodworkingShop.Domain.Entities
{
    public class CartItemSet
    {
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public CartItemSet(Guid cartId, Guid productId, int quantity)
        {
            CartId = cartId;
            ProductId = productId;
            Quantity = quantity;
        }

        public void AddQuantity(int add)
        {
            Quantity += add;
        }

        public void SubtractQuantity(int subtract)
        {
            Quantity -= subtract;
        }
    }
}
