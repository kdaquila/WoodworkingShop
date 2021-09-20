using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoodworkingShop.Domain;
using WoodworkingShop.Infrastructure;

namespace WoodworkingShop.WebMvc
{
    public class CartViewModelService
    {
        IRepository<Cart> _carts { get; set; }
        ICartService _cartService { get; }

        public CartViewModelService(IRepository<Cart> carts, ICartService cartService)
        {
            _carts = carts;
            _cartService = cartService;
        }

        public async Task<CartViewModel> GetCartViewModel(string cartIdStr)
        {
            Guid cartId = new Guid(cartIdStr);
            CartViewModel cartViewModel = new CartViewModel();
            QueryOptions<Cart> options = new QueryOptions<Cart>();
            options.IncludeStrings.Add("CartItemSets");
            options.IncludeStrings.Add("CartItemSets.Product");
            List<Cart> carts = await _carts.ListAsync(options);
            Cart cart = carts[0];

            // Create cart if it no Id is given
            if (cart == null)
            {
                cartId = Guid.NewGuid();
                await _cartService.CreateNewCartAsync(cartId);
                return cartViewModel;
            }
            else
            {                
                foreach (CartItemSet itemSet in cart.CartItemSets)
                {
                    CartItemSetViewModel itemSetViewModel = new CartItemSetViewModel(
                        productId: itemSet.ProductId,
                        name: itemSet.Product.Name,
                        quantity: itemSet.Quantity);

                    cartViewModel.ItemSets.Add(itemSetViewModel);
                }
                return cartViewModel;
            }                           
        }
    }
}
