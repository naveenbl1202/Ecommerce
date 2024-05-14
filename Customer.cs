using System;
using System.Collections.Generic;
using System.IO;

namespace ECommerceSystem
{
    public class Customer
    {
        public static void RegisterCustomer()
        {
            Console.WriteLine("\nRegister New Customer:");
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Address: ");
            string address = Console.ReadLine();

            List<string> customerInfo = new List<string>();
            customerInfo.Add($"{username},{password},{name},{address}");

            File.AppendAllLines("customers.txt", customerInfo);
            Console.WriteLine("Customer registered successfully.");
        }

        public static void CustomerLogin()
        {
            Console.WriteLine("\nCustomer Login:");
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            if (CheckCustomerCredentials(username, password))
            {
                Console.WriteLine("Customer login successful.");
                Menu.CustomerMenu(username);
            }
            else
            {
                Console.WriteLine("Invalid username or password.");
            }
        }

        private static bool CheckCustomerCredentials(string username, string password)
        {
            string[] customerInfo = File.ReadAllLines("customers.txt");
            foreach (string line in customerInfo)
            {
                string[] customer = line.Split(',');
                if (customer[0] == username && customer[1] == password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
