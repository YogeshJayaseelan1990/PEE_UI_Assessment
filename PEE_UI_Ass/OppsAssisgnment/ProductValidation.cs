
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEE_UI_Assessment.OppsAssisgnment
{
    public class ProductValidation
    {
        
        [Test]
        public void Test_GroupProductsByCategory()
        {
            // Arrange
            List<Product> products = new List<Product>
            {
             new Product("Mango", 100, "Fruits"),
             new Product("T-shirt", 8000, "Clothing"),
             new Product("Shirt", 450, "Clothing"),
             new Product("Jeans", 80, "Clothing"),
             new Product("Fan", 200, "Appliances")
            };

            var grouped = GroupProduct.GroupProductsByCategory(products);
            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(3, grouped.Count);
            Console.WriteLine("The Total number of Group Matches" + grouped.Count);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, grouped["Fruits"].Count);
            Console.WriteLine("The Total number of Fruites Category Matches" + grouped["Fruits"].Count);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(3, grouped["Clothing"].Count);
            Console.WriteLine("The Total number of Clothing Category Matches" + grouped["Clothing"].Count);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, grouped["Appliances"].Count);
            Console.WriteLine("The Total number of Appliances Category Matches" + grouped["Appliances"].Count);

        }
    }
}
