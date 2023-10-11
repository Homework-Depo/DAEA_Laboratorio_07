using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data;

namespace Business
{
    public class BProduct
    {
        public List<Product> GetByName(string Name)
        {
            List<Product> result = new List<Product>();
            DProduct data = new DProduct();
            var products = data.Get();

            foreach (var product in products)
            {
                if (product.Name == Name)
                {
                    result.Add(product);
                }
            }
            return result;
        }
    }
}
