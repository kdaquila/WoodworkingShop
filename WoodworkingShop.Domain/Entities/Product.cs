using System;
using System.Collections.Generic;

namespace WoodworkingShop.Domain
{
    public class Product : BaseEntity
    {        
        public string Name { 
            get { return _name; } 
            set {
                if (value == null) throw new ArgumentException("Name must not be null");
                if (value.Length == 0) throw new ArgumentException("Name must not be empty");
                _name = value;
            } 
        }        
                
        public string Description { 
            get { return _description; } 
            set {
                if (value == null) throw new ArgumentException("Description must not be null");
                if (value.Length == 0) throw new ArgumentException("Description must not be empty");
                _description = value;
            }
        }
                
        public decimal Price { 
            get { return _price; }
            set {
                if (value < 0) throw new ArgumentException("Price must not be negative");
                _price = value;
            } 
        }

        public ICollection<ProductProductCategory> ProductProductCategories { get; set; }

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
