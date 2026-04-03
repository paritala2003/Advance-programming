using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Queue<Order> ordersQueue = new Queue<Order>();
        int orderCounter = 1;
        int choice = -1;

        Console.WriteLine("Welcome to Delicious Churros!");

        while (choice != 0)
        {
            Console.WriteLine("\n--- Menu ---");
            Console.WriteLine("1. Place Order");
            Console.WriteLine("2. Deliver Order");
            Console.WriteLine("0. Exit");

            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    double totalBill = 0;
                    string moreItems = "y";

                    // loop for multiple items
                    while (moreItems == "y")
                    {
                        Console.WriteLine("\nSelect Churros:");
                        Console.WriteLine("1. Plain Sugar (6 EUR)");
                        Console.WriteLine("2. Cinnamon Sugar (6 EUR)");
                        Console.WriteLine("3. Chocolate (8 EUR)");
                        Console.WriteLine("4. Nutella (8 EUR)");

                        Console.Write("Enter choice: ");
                        int item = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter quantity: ");
                        int qty = Convert.ToInt32(Console.ReadLine());

                        // temporary order for calculation
                        Order tempOrder = new Order(orderCounter, item, qty);
                        totalBill += tempOrder.pay_bill();

                        Console.Write("Add another item? (y/n): ");
                        moreItems = Console.ReadLine().ToLower();
                    }

                    Console.WriteLine("Total bill: EUR " + totalBill);

                    // store order in queue
                    Order finalOrder = new Order(orderCounter, 1, 1); // simple placeholder
                    ordersQueue.Enqueue(finalOrder);

                    Console.WriteLine("Order placed! Your order number is: " + orderCounter);

                    orderCounter++;
                    break;

                case 2:
                    if (ordersQueue.Count > 0)
                    {
                        Order delivered = ordersQueue.Dequeue();
                        Console.WriteLine("Order " + delivered.getOrderNo() + " delivered!");
                    }
                    else
                    {
                        Console.WriteLine("No orders to deliver.");
                    }
                    break;

                case 0:
                    Console.WriteLine("Exiting system...");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}