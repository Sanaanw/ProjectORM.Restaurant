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
        }   
    }
}
