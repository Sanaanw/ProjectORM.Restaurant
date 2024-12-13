using Restaurant.App.Controllers;
using Restaurant.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.App.ManageRestoran
{
    public class ManageMenuItems
    {

        public void ManageMenuItem()
        {
            MenuItemController menuItemController = new();
            OrderItemController orderItemController = new();
            OrderController orderController = new();
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
                string menuChoice = Console.ReadLine();
                var inputMenu = Console.ReadLine();
                if (!int.TryParse(inputMenu, out int menuAnswer))
                    throw new InAppropriateValueException("Pls enter number");
                switch (menuAnswer)
                {
                    case 0:
                        MenuResult = false;
                        //Console.WriteLine("Returning to the previous menu");
                        //Thread.Sleep(1000);
                        break;
                    default:
                        Console.WriteLine("Pls Add appropriate command");
                        break;
                }

            } while (MenuResult);
        }
    }
}
