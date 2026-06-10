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
            Console.WriteLine("Application started successfully.");
        }
    }
}
