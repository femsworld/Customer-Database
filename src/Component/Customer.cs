#nullable disable
// public static List<Customer> ReadCustomersFromCSV(string filePath)
// {
//     List<Customer> customers = new List<Customer>();

//     if (File.Exists(filePath))
//     {
//         string[] lines = File.ReadAllLines(filePath);

//         for (int i = 1; i < lines.Length; i++)
//         {
//             string[] data = lines[i].Split(',');

//             Customer customer = new Customer();

//             if (int.TryParse(data[0], out int id))
//             {
//                 customer.Id = id;
//             }
//             else
//             {
//                 Console.WriteLine($"Invalid ID format at line {i + 1}. Skipping this customer.");
//                 continue;
//             }

//             {
//                 customer.FirstName = data[1];
//                 customer.LastName = data[2];
//                 customer.Email = data[3];
//                 customer.Address = data[4];

//                 customers.Add(customer);
//             };


//         }
//     }
//     return customers;
// }

// // static void WriteCustomersToCSV(string filePath, List<Customer> customers)
// // {
// //     using (StreamWriter writer = new StreamWriter(filePath))
// //     {
// //         writer.WriteLine("ID,First Name,Last Name,Email,Address");

// //         foreach (Customer customer in customers)
// //         {
// //             writer.WriteLine($"{customer.Id},{customer.FirstName},{customer.LastName},{customer.Email},{customer.Address}");
// //         }
// //     }
// // }

// static Customer SearchCustomerById(List<Customer> customers, int customerId)
// {
//     Customer foundCustomer = customers.Find(customer => customer.Id == customerId);
//     return foundCustomer;
// }
// public class Customer
// {
//     public int Id { get; set; }
//     public string? FirstName { get; set; }
//     public string? LastName { get; set; }
//     public string? Email { get; set; }
//     public string? Address { get; set; }

// }


namespace CustomerDatabaseSystem
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public static List<Customer> ReadCustomersFromCSV(string filePath)
        {
            List<Customer> customers = new List<Customer>();

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] data = lines[i].Split(',');

                    Customer customer = new Customer();

                    if (int.TryParse(data[0], out int id))
                    {
                        customer.Id = id;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid ID format at line {i + 1}. Skipping this customer.");
                        continue;
                    }

                    customer.FirstName = data[1];
                    customer.LastName = data[2];
                    customer.Email = data[3];
                    customer.Address = data[4];

                    customers.Add(customer);
                }
            }

            return customers;
        }
        public static void WriteCustomersToCSV(string filePath, List<Customer> customers)
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
        public static Customer SearchCustomerById(List<Customer> customers, int customerId)
        {
            Customer foundCustomer = customers.Find(customer => customer.Id == customerId);
            return foundCustomer;
        }

    }
}

