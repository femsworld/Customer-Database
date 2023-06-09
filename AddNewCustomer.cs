using System;
using System.IO;

public class AddNewCustomer
{
    public static void AddCustomer()
    {
        Console.WriteLine("Enter customer information:");

        Console.Write("Customer ID: ");
        string? Id = Console.ReadLine();

        Console.Write("First Name: ");
        string? firstName = Console.ReadLine();

        Console.Write("Last Name: ");
        string? lastName = Console.ReadLine();

        Console.Write("Email: ");
        string? email = Console.ReadLine();

        Console.Write("Address: ");
        string? address = Console.ReadLine();

        // Create a new Customer object
        Customer newCustomer = new Customer
        {   
            Id = int.Parse(Id!),
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Address = address
        };

        AppendCustomerToCSV("customers.csv", newCustomer);

        Console.WriteLine("Customer added successfully!");
    }

    private static void AppendCustomerToCSV(string filePath, Customer customer)
    {
        using (StreamWriter writer = new StreamWriter(filePath, true))  //change this to text based class
        {
            writer.WriteLine($"{customer.Id},{customer.FirstName},{customer.LastName},{customer.Email},{customer.Address}");
        }
    }
}
