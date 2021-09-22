using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodworkingShop.Domain
{
    public class Cart : BaseEntity
    {
        public List<CartItemSet> CartItemSets { get; set; }

        public Cart()
        {
            CartItemSets = new List<CartItemSet>();
        }

        public void AddProducts(Guid productId, int quantity)
        {
            if (quantity < 1) throw new CartException("quantity cannot be less than one");

            CartItemSet exitingCartItemSet = CartItemSets.Find(c => c.ProductId == productId);

            if (exitingCartItemSet == null)
            {
                CartItemSets.Add(new CartItemSet(Id, productId, quantity));
            }
            else
            {
                exitingCartItemSet.AddQuantity(quantity);
            }            
        }

        public void SetProducts(Guid productId, int quantity)
        {
            if (quantity < 0) throw new CartException("quantity cannot be less than zero");

            CartItemSet exitingCartItemSet = CartItemSets.Find(c => c.ProductId == productId);

            if (exitingCartItemSet == null)
            {
                CartItemSets.Add(new CartItemSet(Id, productId, quantity));
            }
            else
            {
                exitingCartItemSet.Quantity = quantity;
            }
        }

    }
}
