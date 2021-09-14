using System;

namespace WoodworkingShop.Domain
{
    public class Product : BaseEntity
    {
        private string _name;
        public string Name { 
            get { return _name; } 
            set {
                if (value == null) throw new ArgumentException("Must not be null", nameof(Name));
                if (value.Length == 0) throw new ArgumentException("Must not be empty", nameof(Name));
                _name = value;
            } 
        }

        private string _description;
        public string Description { 
            get { return _description; } 
            set {
                if (value == null) throw new ArgumentException("Must not be null", nameof(Description));
                if (value.Length == 0) throw new ArgumentException("Must not be empty", nameof(Description));
                _description = value;
            }
        }

        private decimal _price;
        public decimal Price { 
            get { return _price; }
            set {
                if (value < 0) throw new ArgumentException("Must not be negative", nameof(Price));
                _price = value;
            } 
        }

        public Product(Guid id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }

    }
}
