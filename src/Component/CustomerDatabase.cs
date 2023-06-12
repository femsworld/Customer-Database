namespace CustomerDatabaseSystem
{
    class CustomerDatabase
    {
        private List<Customer>? customers;
        private Stack<(String Type, Customer Customer)>? undoStack;
        private Stack<(String Type, Customer Customer)>? redoStack;

        public CustomerDatabase()
        {
            customers = new List<Customer>();
            // undoStack = new Stack<(String Type, Customer Customer)>();
            // redoStack = new Stack<(String Type, Customer Customer)>();
        }

        public static void AddCustomer(List<Customer> customers, string filePath)
        {
            Console.WriteLine("Enter customer information:");

            Console.Write("Customer ID: ");
            string? Id = Console.ReadLine();

            Console.Write("First Name: ");
            string? firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            string? lastName = Console.ReadLine();

            string? email;
            do
            {
                Console.Write("Email: ");
                email = Console.ReadLine();
#nullable disable
                if (!IsEmailUnique(email, customers))
                {
                    Console.WriteLine("Email already exists. Please enter a unique email.");
                }
            } while (!IsEmailUnique(email, customers));

            Console.Write("Address: ");
            string address = Console.ReadLine();

            // Create a new Customer object
            Customer newCustomer = new Customer
            {
                Id = int.Parse(Id!),
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Address = address
            };

            AppendCustomerToCSV("src/customers.csv", newCustomer);

            Console.WriteLine("Customer added successfully!");
        }

        private static bool IsEmailUnique(string email, List<Customer> customers)
        {
            return !customers.Any(customer => customer.Email == email);
        }

        private static void AppendCustomerToCSV(string filePath, Customer customer)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))  //change this to text based class
            {
                writer.WriteLine($"{customer.Id},{customer.FirstName},{customer.LastName},{customer.Email},{customer.Address}");
            }
        }

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
}