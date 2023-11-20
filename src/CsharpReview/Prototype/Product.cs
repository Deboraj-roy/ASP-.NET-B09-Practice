using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class Product : ICloneable
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public object Clone()
        {
         Product product = new Product();
            product.Name = Name;
            product.Price = Price;
            return product;
        }
    }
}
