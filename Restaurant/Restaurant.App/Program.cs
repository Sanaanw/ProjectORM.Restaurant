using Restaurant.App.Controllers;
using Restaurant.App.ManageRestoran;
using Restaurant.Service.Services;

namespace Restaurant.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool MainLoop = true;
            while (MainLoop)
            {
                try
                {
                    MenuItemController menuItemController = new();
                    OrderController orderController = new();
                    ManageMenuItems manageMenuItems = new();
                    ManageOrders manageOrders = new();
                    bool result = true;
                    do
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Menu:");
                        Console.ResetColor();
                        Console.WriteLine("1.Perform operation on the menu.");
                        Console.WriteLine("2.Perform operation on orders.");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("0.Exit ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine();
                        Console.Write("Select your option: ");
                        Console.ResetColor();
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
                                Console.WriteLine("Existing menu...");
                                Thread.Sleep(1000);
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Program ended");
                                Console.ResetColor();
                                result = false;
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Pls Add appropriate command");
                                Console.ResetColor();
                                Thread.Sleep(2000);
                                break;
                        }
                    } while (result);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine();
                    Console.ForegroundColor= ConsoleColor.Green;
                    Console.WriteLine(" - Click here and try again");
                    Console.ReadLine();
                    Console.ResetColor();
                }
            }
        }
    }
}
