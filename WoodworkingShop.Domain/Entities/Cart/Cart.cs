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
            try
            {
                requireMinimumQuantity(quantity, 1);
                CartItemSet itemSet = findItemSet(productId);
                incrementItemSetQuantity(itemSet, quantity);
            }
            catch (CartItemSetNotFound)
            {
                createItemSet(CartItemSets, Id, productId, quantity);
            }
                     
        }

        public void SetProducts(Guid productId, int quantity)
        {
            try
            {
                requireMinimumQuantity(quantity, 0);
                CartItemSet itemSet = findItemSet(productId);
                if (quantity == 0)
                {
                    deleteItemSet(CartItemSets, itemSet);
                }
                else
                {
                    setItemSetQuantity(itemSet, quantity);
                }
            }
            catch (CartItemSetNotFound)
            {
                createItemSet(CartItemSets, Id, productId, quantity);
            }
        }

        private void requireMinimumQuantity(int quantity, int minimum = 0)
        {
            if (quantity < minimum)
            {
                throw new ArgumentException($"quantity cannot be less than {minimum}");
            }
        }

        private CartItemSet findItemSet(Guid productId)
        {
            CartItemSet itemSet = CartItemSets.Find(c => c.ProductId == productId);
            if (itemSet == null)
            {
                throw new CartItemSetNotFound($"Could not find an item set for the ProductId: {productId}");
            }
            return itemSet;
        }

        private void createItemSet(List<CartItemSet> itemSets, Guid cartId, Guid productId, int quantity)
        {
            itemSets.Add(new CartItemSet(Id, productId, quantity));
        }

        private void deleteItemSet(List<CartItemSet> itemSets, CartItemSet itemSet)
        {
            itemSets.Remove(itemSet);
        }

        private void incrementItemSetQuantity(CartItemSet itemSet, int quantity)
        {
            itemSet.Quantity += quantity;
        }

        private void setItemSetQuantity(CartItemSet itemSet, int quantity)
        {
            itemSet.Quantity = quantity;
        }

    }
}
