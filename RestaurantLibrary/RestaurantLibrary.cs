using System;
using System.Collections.Generic;

namespace RestaurantLibrary
{
    // Interface for MenuItem
    public interface IMenuItem
    {
        string Name { get; }
        decimal Price { get; }
        void DisplayDetails();
    }

    // Abstract class implementing the interface
    public abstract class MenuItem : IMenuItem
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        protected MenuItem(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public abstract void DisplayDetails(); // Abstraction
    }

    // Inheritance and Polymorphism
    public class Food : MenuItem
    {
        public string Ingredients { get; private set; }

        public Food(string name, decimal price, string ingredients) : base(name, price)
        {
            Ingredients = ingredients;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"Food: {Name}, Price: {Price:C}, Ingredients: {Ingredients}");
        }
    }

    public class Drink : MenuItem
    {
        public bool IsAlcoholic { get; private set; }

        public Drink(string name, decimal price, bool isAlcoholic) : base(name, price)
        {
            IsAlcoholic = isAlcoholic;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"Drink: {Name}, Price: {Price:C}, Alcoholic: {IsAlcoholic}");
        }
    }

    // Encapsulation
    public class Order
    {
        private readonly List<IMenuItem> _items; // Dependency Inversion Principle

        public Order()
        {
            _items = new List<IMenuItem>();
        }

        public void AddItem(IMenuItem item)
        {
            _items.Add(item);
        }

        public void RemoveItem(IMenuItem item)
        {
            _items.Remove(item);
        }

        public void DisplayOrder()
        {
            Console.WriteLine("\nOrder Summary:");
            foreach (var item in _items)
            {
                item.DisplayDetails();
            }

            Console.WriteLine($"Total: {_items.Count} items\n");
        }
    }
}
