using System.Collections.Generic;
using FourthCoffee.Model;

namespace FourthCoffee.Data
{
    public interface IProductsService
    {
        public IList<Product> Products { get; }
    }
}