using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEE_UI_Assessment.OppsAssisgnment
{
    public class Product
    {
        // Properties (Encapsulation)
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        // Constructor
        public Product(string name, decimal price, string category)
        {
            Name = name;
            Price = price;
            Category = category;
        }
    }
}
