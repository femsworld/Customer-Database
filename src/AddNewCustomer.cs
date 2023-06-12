// namespace CustomerDatabase
// {
// public class AddNewCustomer
// {
//     public static void AddCustomer(List<Customer> customers, string filePath)
//     {
        
//         Console.WriteLine("Enter customer information:");

//         Console.Write("Customer ID: ");
//         string? Id = Console.ReadLine();

//         Console.Write("First Name: ");
//         string? firstName = Console.ReadLine();

//         Console.Write("Last Name: ");
//         string? lastName = Console.ReadLine();

//         string? email;
//         do
//         {
//             Console.Write("Email: ");
//             email = Console.ReadLine();
//              #nullable disable
//             if (!IsEmailUnique(email, customers))
//             {
//                 Console.WriteLine("Email already exists. Please enter a unique email.");
//             }
//         } while (!IsEmailUnique(email, customers));

//         Console.Write("Address: ");
//         string address = Console.ReadLine();

//         // Create a new Customer object
//         Customer newCustomer = new Customer
//         {
//             Id = int.Parse(Id!),
//             FirstName = firstName,
//             LastName = lastName,
//             Email = email,
//             Address = address
//         };

//         AppendCustomerToCSV("src/customers.csv", newCustomer);

//         Console.WriteLine("Customer added successfully!");
//     }

//     private static bool IsEmailUnique(string email, List<Customer> customers) 
//     {
//         return !customers.Any(customer => customer.Email == email);
//     }

//     private static void AppendCustomerToCSV(string filePath, Customer customer)
//     {
//         using (StreamWriter writer = new StreamWriter(filePath, true))  //change this to text based class
//         {
//             writer.WriteLine($"{customer.Id},{customer.FirstName},{customer.LastName},{customer.Email},{customer.Address}");
//         }
//     }
// }
// }



