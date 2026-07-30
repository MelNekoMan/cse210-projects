using System;

class Program
{
    static void Main(string[] args)
    {
        Product p1 = new Product("Wireless Mouse", "P101", 25.99, 1);
        Product p2 = new Product("Wireless Charger MagSafe", "P102", 79.50, 2);
        Product p3 = new Product("Wireless Headset", "P103", 50.50, 1);
        Product p4 = new Product("USB-C Cable", "P104", 9.99, 2);
        Product p5 = new Product("Mechanical Keyboard", "P105", 71.45, 1);

        Address usaAddress = new Address("742 Evergreen Terrace", "Springfield", "OR", "USA");
        Customer usaCustomer = new Customer("Alan Wolf", usaAddress);

        Order order1 = new Order(usaCustomer);
        order1.AddProduct(p1);
        order1.AddProduct(p2);

        Address intlAddress = new Address("Av. Principal", "Caracas", "La Vega", "Venezuela");
        Customer intlCustomer = new Customer("Melvin Alvarez", intlAddress);

        Order order2 = new Order(intlCustomer);
        order2.AddProduct(p3);
        order2.AddProduct(p4);
        order2.AddProduct(p5);

        Console.WriteLine("========================================");
        Console.WriteLine("ORDER 1 (USA)");
        Console.WriteLine("========================================");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalCost():F2}\n");

        Console.WriteLine("========================================");
        Console.WriteLine("ORDER 2 (INTERNATIONAL)");
        Console.WriteLine("========================================");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalCost():F2}\n");
    }
}