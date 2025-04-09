using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEE_UI_Assessment.OppsAssisgnment
{
    public class GroupProduct
    {
        
      public static Dictionary<string, List<Product>> GroupProductsByCategory(List<Product> products)
        {
            return products.GroupBy(prod => prod.Category)
            .ToDictionary(group => group.Key, group => group.ToList());
        }
    }
}
