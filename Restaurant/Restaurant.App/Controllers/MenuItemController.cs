﻿using Restaurant.Core.Entities;
using Restaurant.Service.Services;

namespace Restaurant.App.Controllers
{
    public class MenuItemController
    {
        private readonly MenuItemService _menuItemService;
        public MenuItemController()
        {
            _menuItemService = new MenuItemService();
        }
        public void AddMenuItem(MenuItem _menuItem)
        {
            _menuItemService.CreateMenuItem(_menuItem);
            Console.WriteLine($"{_menuItem} added to Menu.");
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine( );
            Console.WriteLine("Menu items:");
            Console.ResetColor();
            foreach (var item in MenuItems())
            {
                Console.WriteLine(item);
            }
        }
        public void EditMenuItem(int _id, MenuItem _menuItem)
        {
            _menuItemService.EditMenuItem(_id, _menuItem);
            Console.WriteLine( );
            Console.WriteLine($"Edited MenuItem with {_id} ID.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("Menu items:");
            Console.ResetColor();
            foreach (var item in MenuItems())
            {
                Console.WriteLine(item);
            }
        }
        public void RemoveMenuItem(int _id)
        {
            _menuItemService.DeleteById(_id);
            Console.WriteLine( );
            Console.WriteLine($"Removed item with {_id} ID.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("Menu items:");
            Console.ResetColor();
            foreach (var item in MenuItems())
            {
                Console.WriteLine(item);
            }
        }
        public List<MenuItem> MenuItems()
        {
            return _menuItemService.GetAllItems();
        }
        public List<MenuItem> MenuItemsByCategory(string _category)
        {
            return _menuItemService.GetItemByCategory(_category);
        }
        public List<MenuItem> MenuItemsByPriceInterval(int _minPrice, int _maxPrice)
        {
            return _menuItemService.GetItemByPriceInterval(_minPrice, _maxPrice);
        }
        public List<MenuItem> SearchMenuItems(string _name)
        {
            return _menuItemService.GetWithSearch(_name);
        }

    }
}
