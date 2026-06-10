using System;
using System.Collections.Generic;
using SIMS.Models;
using SIMS.Repositories;

namespace SIMS.Services
{
    public class InventoryService
    {
        private readonly IProductRepository _productRepository;

        public InventoryService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void CreateProduct(string name, decimal price, int quantity)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Product name cannot be empty.", nameof(name));
            }

            if (price < 0)
            {
                throw new ArgumentException("Price must be greater than or equal to zero.", nameof(price));
            }

            if (quantity < 0)
            {
                throw new ArgumentException("Quantity must be greater than or equal to zero.", nameof(quantity));
            }

            var product = new Product
            {
                Name = name,
                Price = price,
                Quantity = quantity
            };

            _productRepository.Add(product);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }
    }
}
