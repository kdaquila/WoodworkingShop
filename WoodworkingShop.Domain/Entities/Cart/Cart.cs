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
            validateQuantity(quantity);

            CartItemSet itemSet = findItemSet(productId);

            if (itemSet == null && quantity > 0)
            {
                createItemSet(CartItemSets, Id, productId, quantity);
            }
            else if (itemSet != null && quantity > 0)
            {
                incrementItemSetQuantity(itemSet, quantity);
            }
        }

        public void SetProducts(Guid productId, int quantity)
        {
            validateQuantity(quantity);

            CartItemSet itemSet = findItemSet(productId);

            if (itemSet == null && quantity > 0)
            {
                createItemSet(CartItemSets, Id, productId, quantity);
            }
            else if (itemSet != null && quantity > 0)
            {
                setItemSetQuantity(itemSet, quantity);
            }
            else if (itemSet != null && quantity == 0)
            {
                deleteItemSet(CartItemSets, itemSet);
            }
        }

        private void validateQuantity(int quantity)
        {
            if (quantity < 0) {
                throw new ArgumentException("quantity cannot be less than zero");
            }
        }

        private CartItemSet findItemSet(Guid productId)
        {
            return CartItemSets.Find(c => c.ProductId == productId);

        }

        private void createItemSet(List<CartItemSet> itemSets, Guid cartId, Guid productId, int quantity)
        {
            itemSets.Add(new CartItemSet(Id, productId, quantity));
        }

        private void incrementItemSetQuantity(CartItemSet itemSet, int quantity)
        {
            itemSet.Quantity += quantity;
        }

        private void setItemSetQuantity(CartItemSet itemSet, int quantity)
        {
            itemSet.Quantity = quantity;
        }

        private void deleteItemSet(List<CartItemSet> itemSets, CartItemSet itemSet)
        {
            itemSets.Remove(itemSet);
        }
    }
}
