using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodworkingShop.Domain
{
    public class CartItemSetNotFound : Exception
    {
        public CartItemSetNotFound(string message) : base(message)
        {
        }
    }
}
