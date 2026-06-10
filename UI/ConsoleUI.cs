using System;
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
            Console.WriteLine("Inventory Management System");
            Console.WriteLine("Application started successfully.\n");
            
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
    }
}
