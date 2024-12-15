using Restaurant.App.Controllers;
using Restaurant.App.ManageRestoran;
using Restaurant.Service.Services;

namespace Restaurant.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MenuItemController menuItemController = new();
                OrderItemController orderItemController = new();
                OrderController orderController = new();
                ManageMenuItems manageMenuItems = new();
                ManageOrders manageOrders = new();
                bool result = true;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Menu:");
                    Console.WriteLine("1.Perform operation on the menu");
                    Console.WriteLine("2.Perform operation on orders");
                    Console.WriteLine("0.Exit ");
                    Console.Write("Select your option: ");
                    var input = Console.ReadLine();
                    if (!int.TryParse(input, out int answer))
                        answer = 100;
                    bool MenuResult = true;
                    switch (answer)
                    {
                        case 1:
                            manageMenuItems.ManageMenuItem();
                            break;
                        case 2:
                            manageOrders.ManageOrder();
                            break;
                        case 0:
                            Console.WriteLine("Existing menu");
                            Thread.Sleep(1000);
                            result = false;
                            break;
                        default:
                            Console.WriteLine("Pls Add appropriate command");
                            Thread.Sleep(1000);
                            break;
                    }
                } while (result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
