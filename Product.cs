using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ECommerceSystem
{
    public class Product
    {
        public static void AddProduct()
        {
            Console.WriteLine("\nAdd Product:");
            Console.Write("Product Name: ");
            string name = Console.ReadLine();
            Console.Write("Category: ");
            string category = Console.ReadLine();
            Console.Write("Price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            List<string> products = new List<string>();
            products.Add($"{name},{category},{price}");

            File.AppendAllLines("products.txt", products);
            Console.WriteLine("Product added successfully.");
        }

        public static void RemoveProduct()
        {
            Console.WriteLine("\nRemove Product:");
            Console.WriteLine("Choose a product to remove:");
            ViewAllProducts();
            Console.Write("Enter the product ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            List<string> products = File.ReadAllLines("products.txt").ToList();
            products.RemoveAt(id - 1);

            File.WriteAllLines("products.txt", products);
            Console.WriteLine("Product removed successfully.");
        }

        public static void ViewAllProducts()
        {
            Console.WriteLine("\nAll Products:");
            string[] products = File.ReadAllLines("products.txt");
            for (int i = 0; i < products.Length; i++)
            {
                string[] productInfo = products[i].Split(',');
                Console.WriteLine($"{i + 1}. {productInfo[0]} - {productInfo[1]} - {productInfo[2]} kr");
            }
        }
    }
}
