using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RestaurantSystem
{
    class Program
    {
        static string dataFilePath = "orderData.txt";
        static bool isStudent = false; // Flag to determine if the user is a student

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Restaurant System!");

            // Ask if the user is a student
            isStudent = IsStudent();

            // Load existing order or create a new one
            RestaurantLibrary.Order order = LoadOrder();

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add Food");
                Console.WriteLine("2. Add Drink");
                Console.WriteLine("3. View Order");
                Console.WriteLine("4. View Order by Type");
                Console.WriteLine("5. Search for an Item");
                Console.WriteLine("6. Remove Item");
                Console.WriteLine("7. Most Purchased Items");
                Console.WriteLine("8. Calculate Total");
                Console.WriteLine("9. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        string foodName = GetValidText("Enter food name: ");
                        decimal foodPrice = GetValidDecimal("Enter food price: ");
                        string ingredients = GetValidText("Enter food ingredients: ");
                        string foodDescription = GetValidText("Enter a description for the food: ");
                        int foodQuantity = GetValidInt("Enter food quantity: ");
                        double foodRating = GetValidDouble("Enter food rating (0-5): ");

                        if (isStudent)
                        {
                            foodPrice *= 0.8m; // Apply 20% discount
                        }

                        order.AddItem(new RestaurantLibrary.food_class(foodName, foodPrice, ingredients, foodDescription, foodQuantity, foodRating));
                        break;

                    case "2":
                        string drinkName = GetValidText("Enter drink name: ");
                        decimal drinkPrice = GetValidDecimal("Enter drink price: ");
                        bool isAlcoholic = GetIsAlcoholic();
                        string drinkDescription = GetValidText("Enter a description for the drink: ");
                        int drinkQuantity = GetValidInt("Enter drink quantity: ");
                        double drinkRating = GetValidDouble("Enter drink rating (0-5): ");

                        order.AddItem(new RestaurantLibrary.drink_class(drinkName, drinkPrice, isAlcoholic, drinkDescription, drinkQuantity, drinkRating));
                        break;

                    case "3":
                        order.DisplayOrder();
                        break;

                    case "4":
                        order.DisplayOrderByType();
                        break;

                    case "5":
                        string searchName = GetValidText("Enter the name of the item to search: ");
                        order.SearchItem(searchName);
                        break;

                    case "6":
                        string itemName = GetValidText("Enter the name of the item to remove: ");
                        bool removed = order.RemoveItem(itemName);
                        if (removed)
                        {
                            Console.WriteLine($"{itemName} has been removed from the order.");
                        }
                        else
                        {
                            Console.WriteLine($"Item '{itemName}' not found in the order.");
                        }
                        break;

                    case "7":
                        order.DisplayMostPurchasedItems();
                        break;

                    case "8":
                        order.CalculateTotal(isStudent);
                        break;

                    case "9":
                        SaveOrder(order);
                        Console.WriteLine("Thank you for using the Restaurant System!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static bool IsStudent()
        {
            while (true)
            {
                Console.Write("Are you a student? (yes/no): ");
                string input = Console.ReadLine().ToLower();

                if (input == "yes")
                {
                    Console.WriteLine("Student discount will be applied to all foods.");
                    return true;
                }
                else if (input == "no")
                {
                    Console.WriteLine("No discount will be applied.");
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                }
            }
        }

        static void SaveOrder(RestaurantLibrary.Order order)
        {
            using (StreamWriter writer = new StreamWriter(dataFilePath))
            {
                foreach (var item in order.Items)
                {
                    if (item is RestaurantLibrary.food_class food)
                    {
                        writer.WriteLine($"Food|{food.Name}|{food.Price}|{food.Ingredients}|{food.Description}|{food.Quantity}|{food.Rating}");
                    }
                    else if (item is RestaurantLibrary.drink_class drink)
                    {
                        writer.WriteLine($"Drink|{drink.Name}|{drink.Price}|{(drink.IsAlcoholic ? "Alcoholic" : "Non-Alcoholic")}|{drink.Description}|{drink.Quantity}|{drink.Rating}");
                    }
                }
            }
            Console.WriteLine("Order saved successfully!");
        }

        static RestaurantLibrary.Order LoadOrder()
        {
            var order = new RestaurantLibrary.Order();

            if (File.Exists(dataFilePath))
            {
                var lines = File.ReadAllLines(dataFilePath);
                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    if (parts.Length >= 7 && parts[0] == "Food")
                    {
                        order.AddItem(new RestaurantLibrary.food_class(parts[1], decimal.Parse(parts[2]), parts[3], parts[4], int.Parse(parts[5]), double.Parse(parts[6])));
                    }
                    else if (parts.Length >= 7 && parts[0] == "Drink")
                    {
                        order.AddItem(new RestaurantLibrary.drink_class(parts[1], decimal.Parse(parts[2]), parts[3] == "Alcoholic", parts[4], int.Parse(parts[5]), double.Parse(parts[6])));
                    }
                }
            }

            return order;
        }

        static string GetValidText(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input) && input.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                {
                    return input;
                }

                Console.WriteLine("Invalid input. Please enter a valid text without numbers or special characters.");
            }
        }

        static decimal GetValidDecimal(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (decimal.TryParse(input, out decimal result) && result > 0)
                {
                    return result;
                }

                Console.WriteLine("Invalid input. Please enter a valid positive number.");
            }
        }

        static int GetValidInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (int.TryParse(input, out int result) && result > 0)
                {
                    return result;
                }

                Console.WriteLine("Invalid input. Please enter a valid positive integer.");
            }
        }

        static double GetValidDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (double.TryParse(input, out double result) && result >= 0 && result <= 5)
                {
                    return result;
                }

                Console.WriteLine("Invalid input. Please enter a number between 0 and 5.");
            }
        }

        static bool GetIsAlcoholic()
        {
            while (true)
            {
                Console.Write("Is the drink alcoholic? (yes/no): ");
                string input = Console.ReadLine().ToLower();

                if (input == "yes")
                {
                    Console.WriteLine("The drink is alcoholic.");
                    return true;
                }
                else if (input == "no")
                {
                    Console.WriteLine("The drink is non-alcoholic.");
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                }
            }
        }
    }
}
