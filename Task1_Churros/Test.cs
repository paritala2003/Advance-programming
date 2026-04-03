using System;

class Test
{
    static void Main()
    {
        Console.WriteLine("Running Unit Test...\n");

        // Test Case 1
        Order order1 = new Order(1, 1, 2); // €6 × 2 = 12
        double result1 = order1.pay_bill();

        Console.WriteLine("Test Case 1:");
        Console.WriteLine("Expected: 12");
        Console.WriteLine("Actual: " + result1);

        if (result1 == 12)
            Console.WriteLine("Result: PASS\n");
        else
            Console.WriteLine("Result: FAIL\n");


        // Test Case 2
        Order order2 = new Order(2, 3, 1); // €8 × 1 = 8
        double result2 = order2.pay_bill();

        Console.WriteLine("Test Case 2:");
        Console.WriteLine("Expected: 8");
        Console.WriteLine("Actual: " + result2);

        if (result2 == 8)
            Console.WriteLine("Result: PASS\n");
        else
            Console.WriteLine("Result: FAIL\n");
    }
}