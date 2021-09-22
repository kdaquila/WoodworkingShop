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
        public string DefaultName = "Table Saw";
        public string DefaultDescription = "Jobsite table saw";
        public decimal DefaultPrice = 350.0m;

        [Fact]
        public void UpdateName()
        {
            String Name = "Mitre Saw";
            Product product = new Product(Guid.NewGuid(), name: DefaultName, description: DefaultDescription, price: DefaultPrice);

            product.Name = Name;

            Assert.Equal(Name, product.Name);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void UpdateNameWithInvalid(string name)
        {
            Product product = new Product(Guid.NewGuid(), name: DefaultName, description: DefaultDescription, price: DefaultPrice);
                      
            Assert.Throws<ArgumentException>(() => product.Name = name);
        }

        [Fact]
        public void UpdateDescription()
        {
            String Description = "Jobsite mitre saw";
            Product product = new Product(Guid.NewGuid(), name: DefaultName, description: DefaultDescription, price: DefaultPrice);

            product.Description = Description;

            Assert.Equal(Description, product.Description);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void UpdateDescriptionWithInvalid(string description)
        {
            Product product = new Product(Guid.NewGuid(), name: DefaultName, description: DefaultDescription, price: DefaultPrice);

            Assert.Throws<ArgumentException>(() => product.Description = description);
        }

        [Fact]
        public void UpdatePrice()
        {
            decimal PriceDecimal = 200.0m;
            Product product = new Product(Guid.NewGuid(), name: DefaultName, description: DefaultDescription, price: DefaultPrice);

            product.Price = PriceDecimal;

            Assert.Equal(PriceDecimal, product.Price);
        }

        [Fact]
        public void UpdatePriceWithNegative()
        {
            Product product = new Product(Guid.NewGuid(), name: DefaultName, description: DefaultDescription, price: DefaultPrice);

            Assert.Throws<ArgumentException>(() => product.Price = -200.0m);
        }
    }


}
