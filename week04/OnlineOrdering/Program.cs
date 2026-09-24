using System;
class Program
{
    static void Main(string[] args)
    {
        // First customer and address
        Address address1 = new Address(
            "123 Main Street",
            "Provo",
            "Utah",
            "USA"
        );

        Customer customer1 = new Customer(
            "John Smith",
            address1
        );

        // First ordr
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Laptop", "P001", 800, 1));
        order1.AddProduct(new Product("Mouse", "P002", 25, 2));
        order1.AddProduct(new Product("Keyboard", "P003", 50, 1));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():F2}");

        Console.WriteLine("\n-------------------------\n");

        // Second customer and addresss
        Address address2 = new Address(
            "456 Mabini Street",
            "Manila",
            "Metro Manila",
            "Philippines"
        );

        Customer customer2 = new Customer(
            "Maria Santos",
            address2
        );

        // Second order
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Monitor", "P003", 200, 1));
        order2.AddProduct(new Product("Headset", "P004", 75, 2));
        order2.AddProduct(new Product("Webcam", "P005", 60, 1));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():F2}");
    }
}