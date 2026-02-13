using InventoryPro.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryPro.Services
{
    public class InventoryService
    {
        private readonly List<Product> _items = new List<Product>();

        public void AddMultiple(ICollection<Product> newProducts)
        {
            foreach (var item in newProducts)
            {
                _items.Add(item);
            }
        }


        public Product GetProductById(int id)
        {
            return _items.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetCheapProduct(double maxPrice)
        {
            return _items.Where(p => p.Price <= maxPrice)
                .OrderBy(p => p.Price)
                .ToList();
        }


        public void Print()
        {
            Console.WriteLine($"Total Stock : {_items.Count} items");
            Console.WriteLine($"Total Value : {_items.Sum(p => p.Price)}");
        }
    }
}
