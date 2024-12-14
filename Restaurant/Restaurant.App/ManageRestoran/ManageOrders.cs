using Restaurant.App.Controllers;
using Restaurant.Service.Exceptions;
using Restaurant.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.App.ManageRestoran
{
    public class ManageOrders
    {
        public void ManageOrder()
        {
            OrderItemController orderItemController = new();
            OrderController orderController = new();
            bool orderResult = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Order Operations:");
                Console.WriteLine("1. Add a order");
                Console.WriteLine("2. Cancel an order");
                Console.WriteLine("3. Show all orders");
                Console.WriteLine("4. Show orders by date range");
                Console.WriteLine("5. Show orders by amount range");
                Console.WriteLine("6. Show orders for given date");
                Console.WriteLine("7. Show order details by order number");
                Console.WriteLine("0. Return to the previous menu");
                Console.Write("Enter your choice: ");
                string orderChoice = Console.ReadLine();
                if (!int.TryParse(orderChoice, out int orderAnswer))
                    throw new NotAppropriateValueException("Pls enter number");
                switch (orderAnswer)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Add ID of Menu item that you wanna add: ");
                        var inputMenuItemId1 = Console.ReadLine();
                        if (!int.TryParse(inputMenuItemId1, out int MenuItemId1))
                            throw new NotAppropriateValueException("Pls add ID");
                        Console.Write($"Add count of Menu item: ");
                        var inputCountItem1 = Console.ReadLine();
                        if (!int.TryParse(inputCountItem1, out int CountItem1))
                            throw new NotAppropriateValueException("Pls add count");
                        Console.Write("Add Order ID that Order item is belong to: ");
                        var inputOrderId1 = Console.ReadLine();
                        if (!int.TryParse(inputOrderId1, out int OrderId1))
                            throw new NotAppropriateValueException("Pls add ID");
                        orderItemController.AddOrderItem(new() { MenuItemID = MenuItemId1, Count = CountItem1, OrderID = OrderId1 });
                        Thread.Sleep(2000);
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Enter ID of order that you want remove: ");
                        var inputRemovedOrderID3 = Console.ReadLine();
                        if (!int.TryParse(inputRemovedOrderID3, out int RemovedOrderID3))
                            throw new NotAppropriateValueException("Pls add number of ID");
                        Console.WriteLine("Removing order");
                        orderItemController.RemoveOrderItem(RemovedOrderID3);
                        Thread.Sleep(2000);
                        break;
                    case 3:
                        Console.Clear();
                        orderController.ShowAllOrders();
                        Console.WriteLine("Showing...");
                        Thread.Sleep(3000);
                        break;
                    case 4:
                        Console.Clear();
                        Console.Write("Enter starting Date  in format MM/DD/YYYY: ");
                        var inputStartingDate4 = Console.ReadLine();
                        if (!DateTime.TryParse(inputStartingDate4, out DateTime StartingDate4))
                            throw new NotAppropriateValueException("Pls add Date in format MM/DD/YYYY");
                        Console.Write("Enter ending Date  in format MM/DD/YYYY: ");
                        var inputEndingDate4 = Console.ReadLine();
                        if (!DateTime.TryParse(inputEndingDate4, out DateTime EndingDate4))
                            throw new NotAppropriateValueException("Pls add Date in format MM/DD/YYYY");
                        orderController.GetOrderByDateInterval(StartingDate4, EndingDate4);
                        Thread.Sleep(3000);
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
                        Thread.Sleep(3000);
                        break;
                    case 6:
                        Console.Clear();
                        Console.Write("Enter Date of order in format MM/DD/YYYY: ");
                        var inputDate6 = Console.ReadLine();
                        if (!DateTime.TryParse(inputDate6, out DateTime Date6))
                            throw new NotAppropriateValueException("Pls add Date in format MM/DD/YYYY");
                        orderController.ShowOrdersForGivenDate(Date6);
                        Thread.Sleep(3000);
                        break;
                    case 7: 
                        Console.Clear();
                        Console.WriteLine("Enter Order number");
                        var inputNo7 = Console.ReadLine();
                        if (!int.TryParse(inputNo7, out int No7))
                            throw new NotAppropriateValueException("Pls add Price");
                        orderController.GetOrderByNo(No7);
                        Thread.Sleep(10000);
                        break;
                    case 0:
                        Console.WriteLine("Returning to the previous menu");
                        Thread.Sleep(1000);
                        orderResult = false;
                        break;
                    default:
                        Console.WriteLine("Pls Add appropriate command");
                        break;
                }
            } while (orderResult);
        }
    }
}
