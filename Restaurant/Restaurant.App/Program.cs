using Restaurant.App.Controllers;
using Restaurant.Core.Entities;

namespace Restaurant.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuItemController MenuItemController = new();
            MenuItemController.AddMenuItem(new() { Name = "Pies", Price = 12, Category = "Desserts" });
            MenuItemController.AddMenuItem(new() { Name = "Piesss", Price = 12, Category = "Desserts" });
        }
    }
}
