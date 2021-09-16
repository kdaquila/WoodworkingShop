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
        public void UpdateNameWithValid()
        {
            String Name = "Mitre Saw";
            Product product = new Product(Guid.NewGuid(), name: DefaultName, description: DefaultDescription, price: DefaultPrice);

            product.Name = Name;

            Assert.Equal(Name, product.Name);
        }

        [Fact]
        public void UpdateNameWithNull()
        {
            Product product = new Product(Guid.NewGuid(), name: DefaultName, description: DefaultDescription, price: DefaultPrice);
                      
            Assert.Throws<ArgumentException>(() => product.Name = null);
        }

        [Fact]
        public void UpdateNameWithEmpty()
        {
            Product product = new Product(Guid.NewGuid(), name: DefaultName, description: DefaultDescription, price: DefaultPrice);

            Assert.Throws<ArgumentException>(() => product.Name = "");
        }

        [Fact]
        public void UpdateDescriptionWithValid()
        {
            String Description = "Jobsite mitre saw";
            Product product = new Product(Guid.NewGuid(), name: DefaultName, description: DefaultDescription, price: DefaultPrice);

            product.Description = Description;

            Assert.Equal(Description, product.Description);
        }

        [Fact]
        public void UpdateDescriptionWithEmpty()
        {
            Product product = new Product(Guid.NewGuid(), name: DefaultName, description: DefaultDescription, price: DefaultPrice);

            Assert.Throws<ArgumentException>(() => product.Description = "");
        }

        [Fact]
        public void UpdateDescriptionWithNull()
        {
            Product product = new Product(Guid.NewGuid(), name: DefaultName, description: DefaultDescription, price: DefaultPrice);

            Assert.Throws<ArgumentException>(() => product.Description = null);
        }

        [Fact]
        public void UpdatePriceWithValid()
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
