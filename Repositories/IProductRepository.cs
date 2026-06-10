using System.Collections.Generic;
using SIMS.Models;
namespace SIMS.Repositories
{
    public interface IProductRepository
    {
        void Add(Product product);
        IEnumerable<Product> GetAll();
    }
}
