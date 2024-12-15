using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Entities;
using Restaurant.DataAccess.Data;
using Restaurant.Service.Exceptions;

namespace Restaurant.Service.Services
{
    public class MenuItemService
    {
        private readonly RestaurantContext _Menucontext;
        public MenuItemService()
        {
            _Menucontext = new RestaurantContext();
        }
        public void CreateMenuItem(MenuItem _menuItem)
        {
            if (_Menucontext.menuItems.Any(x => x.Name == _menuItem.Name))
                throw new AlreadyExistsException("This item is already exists");
            _Menucontext.menuItems.Add(_menuItem);
            _Menucontext.SaveChanges();
        }
        public async Task CreateMenuItemAsync(MenuItem _menuItem)
        {
            if (await _Menucontext.menuItems.AnyAsync(x => x.Name == _menuItem.Name))
                throw new AlreadyExistsException("This item is already exists");
            await _Menucontext.menuItems.AddAsync(_menuItem);
            await _Menucontext.SaveChangesAsync();
        }

        public List<MenuItem> GetAllItems()
        {
            return _Menucontext.menuItems.ToList();
        }
        public async Task<List<MenuItem>> GetAllItemsAsync()
        {
            return await _Menucontext.menuItems.ToListAsync();
        }
        public MenuItem GetById(int _id)
        {
            var ExitsMenuItem = _Menucontext.menuItems.SingleOrDefault(x => x.Id == _id);
            if (ExitsMenuItem is null)
                throw new NotFoundException($"Do not found item with {_id}-ID");
            return ExitsMenuItem;
        }
        public async Task<MenuItem> GetByIdAsync(int _id)
        {
            var ExitsMenuItem = await _Menucontext.menuItems.SingleOrDefaultAsync(x => x.Id == _id);
            if (ExitsMenuItem is null)
                throw new NotFoundException($"Do not found item with {_id}-ID");
            return ExitsMenuItem;
        }
        public MenuItem GetItemByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Name is Null");
            var ExitsMenuItem = _Menucontext.menuItems.SingleOrDefault(x => x.Name == name);
            if (ExitsMenuItem is null)
                throw new NotFoundException($"{name} not found.");
            else return ExitsMenuItem;
        }
        public async Task<MenuItem> GetItemByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Name is Null");
            var ExitsMenuItem = await _Menucontext.menuItems.SingleOrDefaultAsync(x => x.Name == name);
            if (ExitsMenuItem is null)
                throw new NotFoundException($"{name} not found.");
            else return ExitsMenuItem;
        }
        public List<MenuItem> GetItemByCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentNullException("Category is Null");
            var ExitsMenuItems = _Menucontext.menuItems.Where(x => x.Category == category).ToList();
            if (!ExitsMenuItems.Any())
                throw new NotFoundException($"Do not found item with {category} Category");
            else return ExitsMenuItems;
        }
        public async Task<List<MenuItem>> GetItemByCategoryAsync(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentNullException("Category is Null");
            var ExitsMenuItems = await _Menucontext.menuItems.Where(x => x.Category == category).ToListAsync();
            if (!ExitsMenuItems.Any())
                throw new NotFoundException($"Do not found item with {category} Category");
            else return ExitsMenuItems;
        }
        public List<MenuItem> GetItemByPriceInterval(int minPrice, int maxPrice)
        {
            List<MenuItem> ExitsMenuItems = _Menucontext.menuItems.Where(x => x.Price > minPrice && x.Price < maxPrice).ToList();
            if (!ExitsMenuItems.Any())
                throw new NotFoundException("Do not found");
            return ExitsMenuItems;
        }
        public async Task<List<MenuItem>> GetItemByPriceIntervalAsync(int minPrice, int maxPrice)
        {
            List<MenuItem> ExitsMenuItems = await _Menucontext.menuItems.Where(x => x.Price > minPrice && x.Price < maxPrice).ToListAsync();
            if (!ExitsMenuItems.Any())
                throw new NotFoundException("Do not found");
            return ExitsMenuItems;
        }
        public List<MenuItem> GetWithSearch(string itemName)
        {
            if (string.IsNullOrWhiteSpace(itemName))
                throw new ArgumentNullException("Name is Null");
            var ExitsMenuItems = _Menucontext.menuItems.Where(x => x.Name.Contains(itemName)).ToList();
            if (!ExitsMenuItems.Any())
                throw new NotFoundException($"Do not found");
            else return ExitsMenuItems;
        }
        public async Task<List<MenuItem>> GetWithSearchAsync(string itemName)
        {
            if (string.IsNullOrWhiteSpace(itemName))
                throw new ArgumentNullException("Name is Null");
            var ExitsMenuItems = await _Menucontext.menuItems.Where(x => x.Name.Contains(itemName)).ToListAsync();
            if (!ExitsMenuItems.Any())
                throw new NotFoundException($"Do not found");
            else return ExitsMenuItems;
        }
        public void EditMenuItem(int id, MenuItem _menuItem)
        {
            var ExistMenuItem = GetById(id);
            if (_Menucontext.menuItems.Any(g => g.Name == _menuItem.Name && g.Id != id))
                throw new AlreadyExistsException("Argument is already exist");
            ExistMenuItem.Name = _menuItem.Name ?? ExistMenuItem.Name;
            ExistMenuItem.Price = _menuItem.Price ?? ExistMenuItem.Price;
            ExistMenuItem.Category = _menuItem.Category ?? ExistMenuItem.Category;
            _Menucontext.SaveChanges();
        }
        public async Task EditMenuItemAsync(int id, MenuItem _menuItem)
        {
            var ExistMenuItem = GetById(id);
            if (await _Menucontext.menuItems.AnyAsync(g => g.Name == _menuItem.Name && g.Id != id))
                throw new AlreadyExistsException("Argument is already exist");
            ExistMenuItem.Name = _menuItem.Name ?? ExistMenuItem.Name;
            ExistMenuItem.Price = _menuItem.Price ?? ExistMenuItem.Price;
            ExistMenuItem.Category = _menuItem.Category ?? ExistMenuItem.Category;
            await _Menucontext.SaveChangesAsync();
        }
        public void DeleteById(int id)
        {
            var ExistMenuItem = GetById(id);
            _Menucontext.menuItems.Remove(ExistMenuItem);
            _Menucontext.SaveChanges();
        }
        public async Task DeleteByIdAsync(int id)
        {
            var ExistMenuItem = GetById(id);
            _Menucontext.menuItems.Remove(ExistMenuItem);
            await _Menucontext.SaveChangesAsync();
        }
    }
}
