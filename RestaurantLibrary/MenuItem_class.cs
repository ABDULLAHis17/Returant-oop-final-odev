using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLibrary
{
    public abstract class MenuItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Rating { get; set; } // Rating out of 5

        public MenuItem(string name, decimal price, string description, int quantity, double rating)
        {
            Name = name;
            Price = price;
            Description = description;
            Quantity = quantity;
            Rating = rating;
        }

        public abstract void DisplayDetails();
    }
}
