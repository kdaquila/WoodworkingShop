using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodworkingShop.Domain.Entities
{
    public class Cart : BaseEntity
    {
        public List<CartItemSet> CartItemSets;

        public Cart()
        {
            CartItemSets = new List<CartItemSet>();
        }

        public void AddCartItems(Guid productId, int quantity)
        {
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

        public void RemoveCartItems(Guid productId, int quantity)
        {
            CartItemSet exitingCartItemSet = CartItemSets.Find(c => c.ProductId == productId);

            if (exitingCartItemSet == null)
            {
                return;
            }

            exitingCartItemSet.SubtractQuantity(quantity);

            if (exitingCartItemSet.Quantity < 0)
            {
                CartItemSets.Remove(exitingCartItemSet);
            }
        }

    }
}
