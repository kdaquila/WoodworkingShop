using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodworkingShop.Domain
{
    public class ProductCategory : BaseEntity
    {
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == null) throw new ArgumentException("Name must not be null");
                if (value.Length == 0) throw new ArgumentException("Name must not be empty");
                _name = value;
            }
        }

        private string _name;

        public ICollection<ProductProductCategory> ProductProductCategory { get; set; }

        public ProductCategory(Guid id, string name)
        {
            Id = id;
            Name = name;
            ProductProductCategory = new List<ProductProductCategory>();
        }
    }
}
