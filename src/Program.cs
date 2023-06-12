#nullable disable

namespace CustomerDatabaseSystem
{

    class Program
    {
        private static List<Customer> customers;
        static void Main()
        {
            string filePath = "src/customers.csv";
            // List<Customer> customers = ReadCustomersFromCSV(filePath);
            // List<Customer> ReadCustomersFromCSV(string filePath)
            customers = FileHelper.ReadCustomersFromCSV(filePath);
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
            string response = Console.ReadLine();
            if (response is not null)
            {
                if (response.ToLower() == "yes")
                {
                    CustomerDatabase.AddCustomer(customers, filePath);
                    customers = FileHelper.ReadCustomersFromCSV(filePath);
                }
            }
            Console.WriteLine("Enter the ID of the customer you want to edit:");

            string customerIdInput = Console.ReadLine();


            if (int.TryParse(customerIdInput, out int customerId))
            {
                CustomerDatabase.EditCustomer(customers, customerId);
                FileHelper.WriteCustomersToCSV(filePath, customers);
            }
            else
            {
                Console.WriteLine("Invalid customer ID. Please try again.");
            }

            Console.WriteLine("Enter the ID of the customer you want to search:");
            string searchIdInput = Console.ReadLine();

            if (int.TryParse(searchIdInput, out int searchId))
            {
                Customer foundCustomer = Customer.SearchCustomerById(customers, searchId);

                if (foundCustomer != null)
                {
                    Console.WriteLine($"Customer found: ID: {foundCustomer.Id}, Name: {foundCustomer.FirstName} {foundCustomer.LastName}");
                }
                else
                {
                    Console.WriteLine($"Customer with ID {searchId} not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid customer ID. Please try again."); 
            }

        }
    }
}
