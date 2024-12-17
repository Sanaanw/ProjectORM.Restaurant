using Restaurant.App.Controllers;
using Restaurant.Service.Exceptions;

namespace Restaurant.App.ManageRestoran
{
    public class ManageMenuItems
    {

        public void ManageMenuItem()
        {
            MenuItemController menuItemController = new();
            bool MenuResult = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Menu Items Operations:");
                Console.WriteLine("1. Add new item");
                Console.WriteLine("2. Update an item");
                Console.WriteLine("3. Remove item");
                Console.WriteLine("4. Show all items");
                Console.WriteLine("5. Show items by category");
                Console.WriteLine("6. Show items by price range");
                Console.WriteLine("7. Search items by name");
                Console.WriteLine("0. Return to the previous menu");
                Console.Write("Enter your choice: ");
                var inputMenu = Console.ReadLine();
                if (!int.TryParse(inputMenu, out int menuAnswer))
                    menuAnswer = 100;
                switch (menuAnswer)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Add name of Menu item: ");
                        string itemName1 = Console.ReadLine();
                        Console.Write($"Add price of Menu item: ");
                        var inputPrice = Console.ReadLine();
                        if (!int.TryParse(inputPrice, out int itemPrice1))
                            throw new NotAppropriateValueException("Pls add value of price");
                        Console.Write("Add category of Menu item: ");
                        string categoryMenuItem = Console.ReadLine();
                        Console.WriteLine("Creating menu item...");
                        menuItemController.AddMenuItem(new() { Name = itemName1, Price = itemPrice1, Category = categoryMenuItem });
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Enter id of item that yo want update: ");
                        var editedInputID2 = Console.ReadLine();
                        if (!int.TryParse(editedInputID2, out int editedMenuId2))
                            throw new NotAppropriateValueException("Pls add number of ID");
                        Console.Write("Add new item name: ");
                        string editedName2 = Console.ReadLine();
                        Console.Write($"Add price of edited item: ");
                        var inputPrice2 = Console.ReadLine();
                        if (!int.TryParse(inputPrice2, out int itemPrice2))
                            throw new NotAppropriateValueException("Pls add value of price");
                        Console.Write("Add category of edited item: ");
                        string categoryEditedItem2 = Console.ReadLine();
                        Console.WriteLine("Updating menu item...");
                        menuItemController.EditMenuItem(editedMenuId2, new() { Name = editedName2, Price = itemPrice2, Category = categoryEditedItem2 });
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();
                        Console.Write("Enter ID of item that you want remove: ");
                        var RemovedItemID3 = Console.ReadLine();
                        if (!int.TryParse(RemovedItemID3, out int RemovedMenuItemID3))
                            throw new NotAppropriateValueException("Pls add number of ID");
                        Console.WriteLine("Removing menu iTem...");
                        menuItemController.RemoveMenuItem(RemovedMenuItemID3);
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine();
                        Console.WriteLine("Menu items:");
                        Console.ResetColor();
                        foreach (var item in menuItemController.MenuItems())
                        {
                            Console.WriteLine(item);
                        }
                        Console.ReadLine();
                        break;
                    case 5:
                        Console.Clear();
                        Console.Write("Enter category of MenuItems: ");
                        string CategoryOfItems5 = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine();
                        Console.WriteLine("Menu items:");
                        Console.ResetColor();
                        foreach (var item in menuItemController.MenuItemsByCategory(CategoryOfItems5))
                        {
                            Console.WriteLine(item);
                        }
                        Console.ReadLine();
                        break;
                    case 6:
                        Console.Clear();
                        Console.Write("Enter Minimum price: ");
                        var inputMinPrice6 = Console.ReadLine();
                        if (!int.TryParse(inputMinPrice6, out int MinPrice6))
                            throw new NotAppropriateValueException("Pls add value of price");
                        Console.Write("Enter Maximum Price: ");
                        var inputMaxPrice6 = Console.ReadLine();
                        if (!int.TryParse(inputMaxPrice6, out int MaxPrice6))
                            throw new NotAppropriateValueException("Pls add value of price");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine();
                        Console.WriteLine("Menu items:");
                        Console.ResetColor();
                        foreach (var item in menuItemController.MenuItemsByPriceInterval(MinPrice6, MaxPrice6))
                        {
                            Console.WriteLine(item);
                        }
                        Console.ReadLine();
                        break;
                    case 7:
                        Console.Clear();
                        Console.Write("Search Menu Item: ");
                        string Searching7 = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine();
                        Console.WriteLine("Menu items:");
                        Console.ResetColor();
                        foreach (var item in menuItemController.SearchMenuItems(Searching7))
                        {
                            Console.WriteLine(item);
                        }
                        Console.ReadLine();
                        break;
                    case 0:
                        Console.WriteLine("Returning to the previous menu...");
                        MenuResult = false;
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Pls Add appropriate command");
                        Console.ReadLine();
                        break;
                }
            } while (MenuResult);
        }
    }
}
