using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLibrary
{
    public class drink_class : MenuItem
    {
        public bool IsAlcoholic { get; set; }

        public drink_class(string name, decimal price, bool isAlcoholic, string description, int quantity, double rating)
            : base(name, price, description, quantity, rating)
        {
            IsAlcoholic = isAlcoholic;
        }

        public override void DisplayDetails()
        {
            string alcoholStatus = IsAlcoholic ? "Contains Alcohol" : "Non-Alcoholic";
            Console.WriteLine($"Drink: {Name}, Price: ${Price}, Status: {alcoholStatus}, Description: {Description}, Quantity: {Quantity}, Rating: {Rating}/5");
        }
    }
}

