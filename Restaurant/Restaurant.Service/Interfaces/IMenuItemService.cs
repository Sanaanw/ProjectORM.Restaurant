using Restaurant.Core.Entities;

namespace Restaurant.Service.Interfaces
{
    public interface IMenuItemService
    {
        void CreateMenuItem(MenuItem _menuItem);
        Task CreateMenuItemAsync(MenuItem _menuItem);
        void DeleteById(int id);
        Task DeleteByIdAsync(int id);
        void EditMenuItem(int id, MenuItem _menuItem);
        Task EditMenuItemAsync(int id, MenuItem _menuItem);
        List<MenuItem> GetAllItems();
        Task<List<MenuItem>> GetAllItemsAsync();
        MenuItem GetById(int _id);
        Task<MenuItem> GetByIdAsync(int _id);
        List<MenuItem> GetItemByCategory(string category);
        Task<List<MenuItem>> GetItemByCategoryAsync(string category);
        MenuItem GetItemByName(string name);
        Task<MenuItem> GetItemByNameAsync(string name);
        List<MenuItem> GetItemByPriceInterval(int minPrice, int maxPrice);
        Task<List<MenuItem>> GetItemByPriceIntervalAsync(int minPrice, int maxPrice);
        List<MenuItem> GetWithSearch(string itemName);
        Task<List<MenuItem>> GetWithSearchAsync(string itemName);
    }
}