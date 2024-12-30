using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLibrary
{
    public class food_class : MenuItem
    {
        public string Ingredients { get; set; }

        public food_class(string name, decimal price, string ingredients, string description, int quantity, double rating)
            : base(name, price, description, quantity, rating)
        {
            Ingredients = ingredients;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"Food: {Name}, Price: ${Price}, Ingredients: {Ingredients}, Description: {Description}, Quantity: {Quantity}, Rating: {Rating}/5");
        }
    }
}
