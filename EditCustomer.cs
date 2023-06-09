class CustomerManager
{
    public static void EditCustomer(List<Customer> customers, int customerId)
    {   
            #nullable disable
            Customer customerToUpdate = customers.Find(c => c.Id == customerId); 
            #nullable disable
        // Customer customerToUpdate = customers.Find(c => c.Id.HasValue && c.Id.Value == customerId);

        if (customerToUpdate != null)
        {
            Console.WriteLine($"Editing customer with ID: {customerId}");
            Console.WriteLine("Enter new information for the customer:");

            Console.Write("First Name: ");
            customerToUpdate.FirstName = Console.ReadLine();

            Console.Write("Last Name: ");
            customerToUpdate.LastName = Console.ReadLine();

            Console.Write("Email: ");
            customerToUpdate.Email = Console.ReadLine();

            Console.Write("Address: ");
            customerToUpdate.Address = Console.ReadLine();

            Console.WriteLine("Customer updated successfully!");
            
            // WriteCustomersToCSV("customers.csv", customers);
        }
        else
        {
            Console.WriteLine($"Customer with ID {customerId} not found.");
        }
    }
}
