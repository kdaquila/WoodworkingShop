using System;

namespace WoodworkingShop.Domain
{
    public class Product : BaseEntity
    {        
        public string Name { 
            get { return _name; } 
            set {
                if (value == null) throw new ProductException("Name must not be null");
                if (value.Length == 0) throw new ProductException("Name must not be empty");
                _name = value;
            } 
        }        
                
        public string Description { 
            get { return _description; } 
            set {
                if (value == null) throw new ProductException("Description must not be null");
                if (value.Length == 0) throw new ProductException("Description must not be empty");
                _description = value;
            }
        }
                
        public decimal Price { 
            get { return _price; }
            set {
                if (value < 0) throw new ProductException("Price must not be negative");
                _price = value;
            } 
        }

        private string _name;
        private string _description;
        private decimal _price;

        public Product(Guid id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }

    }
}
