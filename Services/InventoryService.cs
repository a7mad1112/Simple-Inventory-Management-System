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
            ValidateProductData(name, price, quantity);

            name = name.Trim();

            if (_productRepository.GetByName(name) != null)
            {
                throw new ArgumentException("A product with this name already exists.", nameof(name));
            }

            var product = new Product
            {
                Name = name,
                Price = price,
                Quantity = quantity
            };

            _productRepository.Add(product);
        }

        public void EditProduct(string oldName, string newName, decimal newPrice, int newQuantity)
        {
            var product = _productRepository.GetByName(oldName);
            if (product == null)
            {
                throw new ArgumentException("Product not found.", nameof(oldName));
            }

            ValidateProductData(newName, newPrice, newQuantity);

            newName = newName.Trim();

            if (Product.NormalizeName(product.Name) != Product.NormalizeName(newName))
            {
                if (_productRepository.GetByName(newName) != null)
                {
                    throw new ArgumentException("A product with this name already exists.", nameof(newName));
                }
            }

            product.Name = newName;
            product.Price = newPrice;
            product.Quantity = newQuantity;

            _productRepository.Update(product);
        }

        public Product? GetProductByName(string name)
        {
            return _productRepository.GetByName(name);
        }

        public void DeleteProduct(string name)
        {
            var product = _productRepository.GetByName(name);
            if (product == null)
            {
                throw new ArgumentException("Product not found.", nameof(name));
            }

            _productRepository.Remove(product);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        private void ValidateProductData(string name, decimal price, int quantity)
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
        }
    }
}
