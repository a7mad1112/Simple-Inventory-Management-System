using System.Collections.Generic;
using SIMS.Models;
namespace SIMS.Repositories
{
    public interface IProductRepository
    {
        void Add(Product product);
        IEnumerable<Product> GetAll();
        Product? GetByName(string name);
        void Update(Product product);
        void Remove(Product product);
    }
}
