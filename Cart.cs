using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ECommerceSystem
{
    public class Cart
    {
        public static void AddToCart(string username)
        {
            Console.WriteLine("\nAdd Product to Cart:");
            Product.ViewAllProducts();
            Console.Write("Enter the product ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            string[] products = File.ReadAllLines("products.txt");
            string product = products[id - 1];
            // Splitting the product information
            string[] productInfo = product.Split(',');
            // Format: username,product name,price
            List<string> cart = new List<string>();
            cart.Add($"{username},{productInfo[0]},{productInfo[2]}");

            File.AppendAllLines("cart.txt", cart);
            Console.WriteLine("Product added to cart.");
        }

        public static void RemoveFromCart(string username)
        {
            Console.WriteLine("\nRemove Product from Cart:");
            ViewCart(username);
            Console.Write("Enter the product ID to remove: ");
            int id = Convert.ToInt32(Console.ReadLine());

            List<string> cart = File.ReadAllLines("cart.txt").ToList();
            cart.RemoveAt(id - 1);

            File.WriteAllLines("cart.txt", cart);
            Console.WriteLine("Product removed from cart.");
        }

        public static void ViewCart(string username)
        {
            Console.WriteLine($"\n{username}'s Cart:");
            string[] cart = File.ReadAllLines("cart.txt");
            foreach (string item in cart)
            {
                string[] cartItem = item.Split(',');
                if (cartItem[0] == username)
                {
                    Console.WriteLine(cartItem[1]);
                }
            }
        }

        public static void Checkout(string username)
        {
            Console.WriteLine("Checkout:");
            ViewCart(username);

            decimal total = 0;
            List<string> purchase = new List<string>();
            string[] cart = File.ReadAllLines("cart.txt");
            foreach (string item in cart)
            {
                string[] cartItem = item.Split(',');
                if (cartItem[0] == username)
                {
                    decimal itemPrice;
                    // To access the price
                    if (decimal.TryParse(cartItem[2], out itemPrice))
                    {
                        total += itemPrice;
                        purchase.Add($"{DateTime.Now}: {cartItem[1]}");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid price format for item: {cartItem[1]}");
                    }
                }
            }

            Console.WriteLine($"Total: {total} kr");

            File.AppendAllLines($"purchase_{username}.txt", purchase);
            File.WriteAllText("cart.txt", "");
            Console.WriteLine("Purchase completed. Thank you for shopping with us!");
        }

        public static void ViewPurchaseHistory(string username)
        {
            Console.WriteLine($"\n{username}'s Purchase History:");
            try
            {
                string[] purchaseHistory = File.ReadAllLines($"purchase_{username}.txt");
                foreach (string purchase in purchaseHistory)
                {
                    Console.WriteLine(purchase);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("No purchase history found.");
            }
        }
    }
}
