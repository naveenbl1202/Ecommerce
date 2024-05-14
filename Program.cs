using System;

namespace ECommerceSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu.MainMenu();
        }

        internal static void AdminLogin()
        {
            Admin.AdminLogin();
        }

        internal static void CustomerLogin()
        {
            Customer.CustomerLogin();
        }

        internal static void RegisterAdmin()
        {
            Admin.RegisterAdmin();
        }

        internal static void RegisterCustomer()
        {
            Customer.RegisterCustomer();
        }
    }
}
