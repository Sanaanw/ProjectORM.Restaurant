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
            _Menucontext.menuItems.AddAsync(_menuItem);
            _Menucontext.SaveChangesAsync();
        }
        public List<MenuItem> GetAll()
        {
            return _Menucontext.menuItems.ToList();
        }
        public MenuItem GetById(int? _id)
        {
            if (_id is null)
                throw new ArgumentNullException("ID is Null");
            var ExitsMenuItem = _Menucontext.menuItems.SingleOrDefault(x => x.Id == _id);
            if (ExitsMenuItem is null)
                throw new NotFoundException($"Do not found item with {_id}-ID");
            else return ExitsMenuItem;
        }
        public MenuItem GetByName(string _name)
        {
            if (_name is null)
                throw new ArgumentNullException("Name is Null");
            var ExitsMenuItem = _Menucontext.menuItems.SingleOrDefault(x => x.Name == _name);
            if (ExitsMenuItem is null)
                throw new NotFoundException($"{_name} not found.");
            else return ExitsMenuItem;
        }
        public void EditMenuItem(int? id, MenuItem _menuItem)
        {
            var ExistMenuItem = GetById(id);
            if (_Menucontext.menuItems.Any(g => g.Name == ExistMenuItem.Name && g.Id != id))
                throw new AlreadyExistsException("Argument is already exist");
            ExistMenuItem.Name = _menuItem.Name;
            ExistMenuItem.Price = _menuItem.Price;
            ExistMenuItem.Category = _menuItem.Category;
             _Menucontext.SaveChangesAsync();
        }
        public void DeleteById(int? id)
        {
            var ExistMenuItem = GetById(id);
            _Menucontext.menuItems.Remove(ExistMenuItem);
        }
    }
}
