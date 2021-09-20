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

        public void RemoveProducts(Guid productId, int quantity)
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
