using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodworkingShop.Domain;
using Xunit;

namespace WoodworkingShop.UnitTests
{
    public class ProductTest
    {
        [Theory]
        [InlineData("Mitre Saw")]
        public void UpdateNameWithValidData(string name)
        {
            Product product = new Product(new Guid(), name: "Table Saw", description: "Jobsite table saw", price: 350.0m);

            product.Name = name;

            Assert.Equal(name, product.Name);
        }
    }


}
