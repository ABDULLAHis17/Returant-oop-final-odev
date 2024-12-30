using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantLibrary
{
    public class Order
    {
        public List<MenuItem> Items { get; set; } = new List<MenuItem>();

        public void AddItem(MenuItem item)
        {
            Items.Add(item);
            Console.WriteLine($"{item.Name} has been added to the order.");
        }

        public bool RemoveItem(string name)
        {
            var item = Items.Find(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (item != null)
            {
                Items.Remove(item);
                return true;
            }
            return false;
        }

        public void DisplayOrder()
        {
            Console.WriteLine("\nYour Order:");
            if (Items.Count == 0)
            {
                Console.WriteLine("No items in the order.");
                return;
            }

            foreach (var item in Items)
            {
                item.DisplayDetails();
            }
        }

        public void DisplayOrderByType()
        {
            Console.WriteLine("\nYour Order by Type:");

            var foods = Items.OfType<food_class>().ToList();
            var drinks = Items.OfType<drink_class>().ToList();

            if (foods.Count > 0)
            {
                Console.WriteLine("\nFoods:");
                foreach (var food in foods)
                {
                    food.DisplayDetails();
                }
            }
            else
            {
                Console.WriteLine("No foods in the order.");
            }

            if (drinks.Count > 0)
            {
                Console.WriteLine("\nDrinks:");
                foreach (var drink in drinks)
                {
                    drink.DisplayDetails();
                }
            }
            else
            {
                Console.WriteLine("No drinks in the order.");
            }
        }

        public void SearchItem(string name)
        {
            var item = Items.Find(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (item != null)
            {
                Console.WriteLine("Item Found:");
                item.DisplayDetails();
            }
            else
            {
                Console.WriteLine($"Item '{name}' not found.");
            }
        }

        public void DisplayMostPurchasedItems()
        {
            if (Items.Count == 0)
            {
                Console.WriteLine("No items in the order to display.");
                return;
            }

            Console.WriteLine("\nMost Purchased Items:");
            var sortedItems = Items.OrderByDescending(i => i.Quantity).Take(3);

            foreach (var item in sortedItems)
            {
                Console.WriteLine($"{item.Name}: {item.Quantity} purchased");
            }
        }

        public void CalculateTotal(bool isStudent)
        {
            decimal total = 0;

            foreach (var item in Items)
            {
                if (item is food_class && isStudent)
                {
                    total += item.Price * item.Quantity; // Discount already applied
                }
                else
                {
                    total += item.Price * item.Quantity;
                }
            }

            Console.WriteLine($"\nTotal Order Price: ${total}");
        }
    }
}
