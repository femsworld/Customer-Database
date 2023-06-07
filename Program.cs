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
            // Console.WriteLine($"Email: {customer.Email}");
            // Console.WriteLine($"Address: {customer.Address}");
            Console.WriteLine();
        }

        // Example: Add a new customer
        Customer newCustomer = new Customer
        {
            Id = 123,
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            Address = "123 Main St"
        };

        customers.Add(newCustomer);

        // Write the updated customer list to the CSV file
        WriteCustomersToCSV(filePath, customers);
    }

    static List<Customer> ReadCustomersFromCSV(string filePath)
    {
        // Existing code for reading customers from the CSV file
        List<Customer> customers = new List<Customer>();

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);

            // Skip the header row (assuming it's the first row)
            for (int i = 1; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');

                Customer customer = new Customer
                {
                    Id = int.Parse(data[0]),
                    FirstName = data[1],
                    LastName = data[2],
                    Email = data[3],
                    Address = data[4]
                };

                customers.Add(customer);
            }
        }

        return customers;
    }

    static void WriteCustomersToCSV(string filePath, List<Customer> customers)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            // Write the header row
            writer.WriteLine("ID,First Name,Last Name,Email,Address");

            foreach (Customer customer in customers)
            {
                // Write the data for each customer
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

