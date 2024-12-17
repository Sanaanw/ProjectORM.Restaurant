using Restaurant.App.Controllers;
using Restaurant.Service.Exceptions;

namespace Restaurant.App.ManageRestoran
{
    public class ManageOrders
    {
        public void ManageOrder()
        {
            OrderController orderController = new();
            bool orderResult = true;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Order Operations: ");
                Console.ResetColor();
                Console.WriteLine("1. Add a order");
                Console.WriteLine("2. Remove an order");
                Console.WriteLine("3. Show all orders");
                Console.WriteLine("4. Show orders by date range");
                Console.WriteLine("5. Show orders by amount range");
                Console.WriteLine("6. Show orders for given date");
                Console.WriteLine("7. Show order details by order number");
                Console.WriteLine("0. Return to the previous menu");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine( );
                Console.Write("Enter your choice: ");
                Console.ResetColor();
                string orderChoice = Console.ReadLine();
                if (!int.TryParse(orderChoice, out int orderAnswer))
                    throw new NotAppropriateValueException("Pls enter number");
                switch (orderAnswer)
                {
                    case 1:
                        Console.Clear();
                        orderController.CreateOrder();
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Enter ID of order that you want remove: ");
                        var inputRemovedOrderID3 = Console.ReadLine();
                        if (!int.TryParse(inputRemovedOrderID3, out int RemovedOrderID3))
                            throw new NotAppropriateValueException("Pls add number of ID");
                        Console.WriteLine("Removing Order...");
                        Console.WriteLine( );
                        orderController.RemoveOrder(RemovedOrderID3);
                        Console.WriteLine( );
                        orderController.ShowAllOrders();
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Getting...");
                        Console.Clear( );
                        orderController.ShowAllOrders();
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Clear();
                        Console.Write("Enter starting Date  in format YYYY/MM/DD (Year,Month,Day): ");
                        var inputStartingDate4 = Console.ReadLine();
                        if (!DateTime.TryParse(inputStartingDate4, out DateTime StartingDate4))
                            throw new NotAppropriateValueException("Pls add Date in format YYYY/MM/DD (Year,Month,Day)");
                        Console.Write("Enter ending Date  in format YYYY/MM/DD (Year,Month,Day): ");
                        var inputEndingDate4 = Console.ReadLine();
                        if (!DateTime.TryParse(inputEndingDate4, out DateTime EndingDate4))
                            throw new NotAppropriateValueException("Pls add Date in format YYYY/MM/DD (Year,Month,Day)");
                        orderController.GetOrderByDateInterval(StartingDate4, EndingDate4);
                        Console.ReadLine();
                        break;
                    case 5:
                        Console.Clear();
                        Console.Write("Enter minimum price: ");
                        var inputMinimumPrice5 = Console.ReadLine();
                        if (!double.TryParse(inputMinimumPrice5, out double MinimumPrice5))
                            throw new NotAppropriateValueException("Pls add Price");
                        Console.Write("Enter maximum price: ");
                        var inputMaximumPrice5 = Console.ReadLine();
                        if (!double.TryParse(inputMaximumPrice5, out double MaximumPrice5))
                            throw new NotAppropriateValueException("Pls add Price");
                        orderController.ShowOrderByAmountRange(MinimumPrice5, MaximumPrice5);
                        Console.ReadLine();
                        break;
                    case 6:
                        Console.Clear();
                        Console.Write("Enter Date of order in format YYYY/MM/DD (Year,Month,Day): ");
                        var inputDate6 = Console.ReadLine();
                        if (!DateTime.TryParse(inputDate6, out DateTime Date6))
                            throw new NotAppropriateValueException("Pls add Date in format YYYY/MM/DD (Year,Month,Day)");
                        orderController.ShowOrdersForGivenDate(Date6);
                        Console.ReadLine();
                        break;
                    case 7:
                        Console.Clear();
                        Console.Write("Enter Order number: ");
                        var inputNo7 = Console.ReadLine();
                        if (!int.TryParse(inputNo7, out int No7))
                            throw new NotAppropriateValueException("Pls add Price");
                        orderController.GetOrderByNo(No7);
                        Console.ReadLine();
                        break;
                    case 0:
                        Console.WriteLine("Returning to the previous menu");
                        Thread.Sleep(1000);
                        orderResult = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Pls Add appropriate command");
                        Console.ResetColor();
                        break;
                }
            } while (orderResult);
        }
    }
}
