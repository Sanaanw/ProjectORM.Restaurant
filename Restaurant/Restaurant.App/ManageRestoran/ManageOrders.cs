using Restaurant.Service.Exceptions;
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
            bool orderResult=true;
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
                    throw new InAppropriateValueException("Pls enter number");
                switch (orderAnswer)
                {
                    case 0:
                        orderResult = false;
                        //Console.WriteLine("Returning to the previous menu");
                        //Thread.Sleep(1000);
                        break;
                    default:
                        Console.WriteLine("Pls Add appropriate command");
                        break;
                }
            } while(orderResult);
        }
    }
}
