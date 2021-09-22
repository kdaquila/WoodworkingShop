using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodworkingShop.Infrastructure
{
    public class DbObjectNotFound : Exception
    {
        public DbObjectNotFound(string message) : base(message)
        {
        }
    }
}
