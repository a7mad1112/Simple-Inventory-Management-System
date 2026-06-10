using System.Collections.Generic;
using System.Linq;
using SIMS.Models;

namespace SIMS.Repositories
{
    public class InMemoryProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>();

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return _products.AsReadOnly();
        }

        public Product? GetByName(string name)
        {
            string normalizedName = Product.NormalizeName(name);
            return _products.FirstOrDefault(p => Product.NormalizeName(p.Name) == normalizedName);
        }
    }
}
