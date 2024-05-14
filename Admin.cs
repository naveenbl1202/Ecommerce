using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ECommerceSystem
{
    public class Admin
    {
        public static void RegisterAdmin()
        {
            Console.WriteLine("\nRegister New Admin:");
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            List<string> adminInfo = new List<string>();
            adminInfo.Add($"{username},{password}");

            File.AppendAllLines("admin.txt", adminInfo);
            Console.WriteLine("Admin registered successfully.");
        }

        public static void AdminLogin()
        {
            Console.WriteLine("\nAdmin Login:");
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            if (CheckAdminCredentials(username, password))
            {
                Console.WriteLine("Admin login successful.");
                Menu.AdminMenu();
            }
            else
            {
                Console.WriteLine("Invalid username or password.");
            }
        }

        private static bool CheckAdminCredentials(string username, string password)
        {
            string[] adminInfo = File.ReadAllLines("admin.txt");
            foreach (string line in adminInfo)
            {
                string[] admin = line.Split(',');
                if (admin[0] == username && admin[1] == password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
