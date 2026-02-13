using System;
using System.Collections.Generic;
using InventoryPro.Models;
using InventoryPro.Services;
class Program
{
    static void Main()
    {
        var service = new InventoryService();

        var initialStock = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1200 },
            new Product { Id = 2, Name = "Mouse", Category = "Electronics", Price = 25 },
            new Product { Id = 3, Name = "Desk Chair", Category = "Furniture", Price = 150 }
        };
        service.AddMultiple(initialStock);

        Console.WriteLine("Budget Item ");
        var cheapItems = service.GetCheapProduct(200);

        foreach (var cheapItem in cheapItems)
        {
            Console.WriteLine($"{cheapItem.Name}  Cost Only : {cheapItem.Price} ");
        }


        Console.WriteLine("Inventory Summary");

        service.Print();
    }
}