using System;

namespace WoodworkingShop.Domain
{
    public class CartItemSetException : Exception
    {
        public CartItemSetException(string message) : base(message)
        {
        }
    }
}
