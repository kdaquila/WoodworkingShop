using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodworkingShop.Domain
{
    public class CartItemSet : BaseEntity
    {
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { 
            get {
                return _quantity;
            } set {
                if (value < 0) throw new CartItemSetException("Quantity cannot be negative");
                _quantity = value;
            } }

        private int _quantity;

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
