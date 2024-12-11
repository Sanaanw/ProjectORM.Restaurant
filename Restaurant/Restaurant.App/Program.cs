using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Restaurant.App.Controllers;
using Restaurant.Core.Entities;
using Restaurant.Service.Exceptions;

namespace Restaurant.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region sjsj
            //OrderItemController OrderItemController = new();
            //bool result = true;
            //do
            //{
            //    Console.WriteLine("1.Operation on the menu");
            //    Console.WriteLine("2.Operation on orders");
            //    Console.WriteLine("3.Quit");
            //    var input = Console.ReadLine();
            //    if (!int.TryParse(input, out int answer))
            //        throw new InAppropriateValueException("Pls enter number");
            //    bool MenuResult=true;
            //    do
            //    {
            //        switch (answer)
            //        {
            //            case 1:
            //                Console.Clear();
            //                Console.WriteLine("1.Add new item");
            //                Console.WriteLine();
            //                break;
            //        }
            //    }
            //    while (MenuResult);
            //} while (result); 
            #endregion
            MenuItemController menuItemController = new();
            OrderItemController orderItemController = new();
            OrderController orderController = new();
           // orderController.CreateOrder(new());
            orderItemController.AddOrderItem(new() { Count=3,MenuItemID=1,OrderID=3004});
        }
    }
}
