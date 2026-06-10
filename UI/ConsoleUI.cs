using System;
using System.Linq;
using SIMS.Services;

namespace SIMS.UI
{
    public class ConsoleUI
    {
        private readonly InventoryService _inventoryService;

        public ConsoleUI(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public void Run()
        {
            bool exit = false;

            while (!exit)
            {
                DisplayMenu();
                string choice = (Console.ReadLine() ?? string.Empty).Trim();

                exit = HandleMenuSelection(choice);
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine("\n=== Inventory Management System ===");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View Products");
            Console.WriteLine("3. Edit Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Search Product");
            Console.WriteLine("0. Exit");
            Console.Write("Select an option: ");
        }

        private bool HandleMenuSelection(string choice)
        {
            switch (choice)
            {
                case "1":
                    HandleAddProduct();
                    return false;
                case "2":
                    HandleViewProducts();
                    return false;
                case "3":
                    HandleEditProduct();
                    return false;
                case "4":
                    HandleDeleteProduct();
                    return false;
                case "5":
                    HandleSearchProduct();
                    return false;
                case "0":
                    Console.WriteLine("\nGoodbye!");
                    return true;
                default:
                    Console.WriteLine("\nError: Invalid option. Please select a valid option from the menu.");
                    return false;
            }
        }

        private void HandleAddProduct()
        {
            Console.WriteLine("\n--- Add Product ---");
            try
            {
                Console.Write("Enter product name: ");
                string name = Console.ReadLine() ?? string.Empty;

                Console.Write("Enter product price: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal price))
                {
                    Console.WriteLine("Error: Invalid price format.");
                    return;
                }

                Console.Write("Enter product quantity: ");
                if (!int.TryParse(Console.ReadLine(), out int quantity))
                {
                    Console.WriteLine("Error: Invalid quantity format.");
                    return;
                }

                _inventoryService.CreateProduct(name, price, quantity);
                Console.WriteLine("\nProduct added successfully!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\nValidation Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nAn unexpected error occurred: {ex.Message}");
            }
        }

        private void HandleViewProducts()
        {
            Console.WriteLine("\n--- Product List ---");
            var products = _inventoryService.GetAllProducts().ToList();

            if (products.Count == 0)
            {
                Console.WriteLine("No products found.");
            }
            else
            {
                foreach (var product in products)
                {
                    Console.WriteLine($"Name: {product.Name}, Price: {product.Price:C}, Quantity: {product.Quantity}");
                }
            }
        }

        private void HandleEditProduct()
        {
            Console.WriteLine("\n--- Edit Product ---");
            try
            {
                Console.Write("Enter the name of the product to edit: ");
                string oldName = Console.ReadLine() ?? string.Empty;

                var product = _inventoryService.GetProductByName(oldName);
                if (product == null)
                {
                    Console.WriteLine("Error: Product not found.");
                    return;
                }

                Console.WriteLine($"\nCurrent values - Name: {product.Name}, Price: {product.Price:C}, Quantity: {product.Quantity}\n");

                Console.Write("Enter new product name: ");
                string newName = Console.ReadLine() ?? string.Empty;

                Console.Write("Enter new product price: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal price))
                {
                    Console.WriteLine("Error: Invalid price format.");
                    return;
                }

                Console.Write("Enter new product quantity: ");
                if (!int.TryParse(Console.ReadLine(), out int quantity))
                {
                    Console.WriteLine("Error: Invalid quantity format.");
                    return;
                }

                _inventoryService.EditProduct(oldName, newName, price, quantity);
                Console.WriteLine("\nProduct updated successfully!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\nValidation Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nAn unexpected error occurred: {ex.Message}");
            }
        }

        private void HandleDeleteProduct()
        {
            Console.WriteLine("\n--- Delete Product ---");
            try
            {
                Console.Write("Enter the name of the product to delete: ");
                string name = Console.ReadLine() ?? string.Empty;

                _inventoryService.DeleteProduct(name);
                Console.WriteLine("\nProduct deleted successfully!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nAn unexpected error occurred: {ex.Message}");
            }
        }

        private void HandleSearchProduct()
        {
            Console.WriteLine("\n--- Search Product ---");
            Console.Write("Enter product name to search: ");
            string name = Console.ReadLine() ?? string.Empty;

            var product = _inventoryService.GetProductByName(name);

            if (product == null)
            {
                Console.WriteLine("\nProduct not found.");
            }
            else
            {
                Console.WriteLine("\n--- Product Details ---");
                Console.WriteLine($"Name: {product.Name}");
                Console.WriteLine($"Price: {product.Price:C}");
                Console.WriteLine($"Quantity: {product.Quantity}");
            }
        }
    }
}
