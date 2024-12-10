using Restaurant.Core.Entities;
using Restaurant.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine($"{_menuItem} added to Menu");
        }
        public List<MenuItem> MenuItems()
        {
            return _menuItemService.GetAllItems();
        }
        public void RemoveMenuItem(int _id)
        {
            _menuItemService.DeleteById(_id);
            Console.WriteLine($"Removed item with {_id} ID");
        }
        public void EditMenuItem(int _id,MenuItem _menuItem)
        {
            _menuItemService.EditMenuItem(_id, _menuItem);
            Console.WriteLine($"Edited MenuItem with {_id} ID");
        }
        public List<MenuItem> MenuItemsByCategory(string _category)
        {
            return _menuItemService.GetItemByCategory(_category);
        }
        public List<MenuItem> MenuItemsByPriceInterval(int _minPrice,int _maxPrice)
        {
            return _menuItemService.GetItemByPriceInterval(_minPrice, _maxPrice);
        }
        public List<MenuItem> SearchMenuItems(string _name)
        {
            return _menuItemService.GetWithSearch(_name);
        }

    }
}
