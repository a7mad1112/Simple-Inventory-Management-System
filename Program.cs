using System;
using Microsoft.Extensions.DependencyInjection;
using SIMS.Repositories;
using SIMS.Services;
using SIMS.UI;

namespace SIMS;

class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();
        ConfigureServices(services);

        var serviceProvider = services.BuildServiceProvider();

        var consoleUI = serviceProvider.GetRequiredService<ConsoleUI>();
        consoleUI.Run();
    }

    static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IProductRepository, InMemoryProductRepository>();
        services.AddSingleton<InventoryService>();
        services.AddSingleton<ConsoleUI>();
    }
}