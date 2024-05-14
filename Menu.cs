using System;
using System.IO;

namespace ECommerceSystem
{
    public class Menu
    {
        public static void MainMenu()
        {
            Console.WriteLine("Welcome to the E-commerce System!");

            while (true)
            {
                Console.WriteLine("\nPlease choose an option:");
                Console.WriteLine("1. Log in as admin");
                Console.WriteLine("2. Log in as customer");
                Console.WriteLine("3. Register as a new customer");
                Console.WriteLine("4. Register as a new admin");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Program.AdminLogin();
                        break;
                    case "2":
                        Program.CustomerLogin();
                        break;
                    case "3":
                        Program.RegisterCustomer();
                        break;
                    case "4":
                        Program.RegisterAdmin();
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        internal static void AdminMenu()
        {
            while (true)
            {
                Console.WriteLine("\nAdmin Menu:");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Remove Product");
                Console.WriteLine("3. View All Products");
                Console.WriteLine("4. View Customer Information");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Product.AddProduct();
                        break;
                    case "2":
                        Product.RemoveProduct();
                        break;
                    case "3":
                        Product.ViewAllProducts();
                        break;
                    case "4":
                        ViewCustomerInfo();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        internal static void ViewCustomerInfo()
        {
            Console.WriteLine("\nCustomer Information:");
            try
            {
                string[] customers = File.ReadAllLines("customers.txt");
                foreach (string customer in customers)
                {
                    Console.WriteLine(customer);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("No customers found.");
            }
        }

        internal static void CustomerMenu(string username)
        {
            while (true)
            {
                Console.WriteLine($"\nCustomer Menu ({username}):");
                Console.WriteLine("1. View All Products");
                Console.WriteLine("2. Add Product to Cart");
                Console.WriteLine("3. Remove Product from Cart");
                Console.WriteLine("4. View Cart");
                Console.WriteLine("5. Checkout");
                Console.WriteLine("6. View Purchase History");
                Console.WriteLine("7. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Product.ViewAllProducts();
                        break;
                    case "2":
                        Cart.AddToCart(username);
                        break;
                    case "3":
                        Cart.RemoveFromCart(username);
                        break;
                    case "4":
                        Cart.ViewCart(username);
                        break;
                    case "5":
                        Cart.Checkout(username);
                        break;
                    case "6":
                        Cart.ViewPurchaseHistory(username);
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
