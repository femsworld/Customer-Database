﻿using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "customers.csv";
        List<Customer> customers = ReadCustomersFromCSV(filePath);

        foreach (Customer customer in customers)
        {
            Console.WriteLine($"ID: {customer.Id}");
            Console.WriteLine($"First Name: {customer.FirstName}");
            // Console.WriteLine($"Last Name: {customer.LastName}");
            Console.WriteLine($"Email: {customer.Email}");
            // Console.WriteLine($"Address: {customer.Address}");
            Console.WriteLine();
        }

        Console.WriteLine("Do you want to enter a new customer? (yes/no)");
        string? response = Console.ReadLine();
        if (response is not null)
        {
            if (response.ToLower() == "yes")
        {
            AddNewCustomer.AddCustomer();
            
            customers = ReadCustomersFromCSV(filePath);
        }
        }
        Console.WriteLine("Enter the ID of the customer you want to edit:");

        string? customerIdInput = Console.ReadLine();
     

        if (int.TryParse(customerIdInput, out int customerId))
        {
            CustomerManager.EditCustomer(customers, customerId);
        }
        else
        {
            Console.WriteLine("Invalid customer ID. Please try again.");
        }
    }
    static List<Customer> ReadCustomersFromCSV(string filePath)
    {
        List<Customer> customers = new List<Customer>();

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');

                Customer customer = new Customer();

                if(int.TryParse(data[0], out int id))
                {
                    customer.Id = id;
                } 
                else {
                    Console.WriteLine($"Invalid ID format at line {i + 1}. Skipping this customer.");
                    continue;
                }
                
                {
                    customer.FirstName = data[1];
                    customer.LastName = data[2];
                    customer.Email = data[3];
                    customer.Address = data[4];

                    customers.Add(customer);
                };

                
            }
        }
        return customers;
    }
    static void WriteCustomersToCSV(string filePath, List<Customer> customers)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("ID,First Name,Last Name,Email,Address");

            foreach (Customer customer in customers)
            {
                writer.WriteLine($"{customer.Id},{customer.FirstName},{customer.LastName},{customer.Email},{customer.Address}");
            }
        }
    }
}

class Customer
{   
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
}

