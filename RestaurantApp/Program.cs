using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Restaurant System!");

            RestaurantLibrary.Order order = new RestaurantLibrary.Order();

            order.AddItem(new RestaurantLibrary.Food("Burger", 150, "Meat, tomato, potato and cheese"));

            order.AddItem(new RestaurantLibrary.Drink("coca cola", 30, false));

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add Food");
                Console.WriteLine("2. Add Drink");
                Console.WriteLine("3. View Order");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter food name: ");
                        string foodName = Console.ReadLine();

                        Console.Write("Enter food price: ");
                        decimal foodPrice = decimal.Parse(Console.ReadLine());

                        Console.Write("Enter food ingredients: ");
                        string ingredients = Console.ReadLine();

                        order.AddItem(new RestaurantLibrary.Food(foodName, foodPrice, ingredients));
                        break;

                    case "2":
                        Console.Write("Enter drink name: ");
                        string drinkName = Console.ReadLine();

                        Console.Write("Enter drink price: ");
                        decimal drinkPrice = decimal.Parse(Console.ReadLine());

                        Console.Write("Is the drink alcoholic? (yes/no): ");
                        bool isAlcoholic = Console.ReadLine().ToLower() == "yes";

                        order.AddItem(new RestaurantLibrary.Drink(drinkName, drinkPrice, isAlcoholic));
                        break;

                    case "3":
                        order.DisplayOrder();
                        break;

                    case "4":
                        Console.WriteLine("Thank you for using the Restaurant System!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
