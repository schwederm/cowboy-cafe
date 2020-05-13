/*
 * Author: Matt Schweder
 * Class Name: DakotaDoubleBurger.cs
 * Purpose: This class holds all the optional ingredients, price, calories, and special instructions for the Dakota Double Burger.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    public class DakotaDoubleBurger : Entree
    {
        /// <summary>
        /// If the Dakota Double Burger comes with buns
        /// </summary>
        private bool bun = true;
        public bool Bun
        {
            get { return bun; }
            set
            {
                bun = value;
                NotifyPropertyChanged("Bun");
            }
        }

        /// <summary>
        /// If the Dakota Double Burger comes with ketchup
        /// </summary>
        private bool ketchup = true;
        public bool Ketchup
        {
            get { return ketchup; }
            set
            {
                ketchup = value;
                NotifyPropertyChanged("Ketchup");
            }
        }

        /// <summary>
        /// If the Dakota Double Burger comes with mustard
        /// </summary>
        private bool mustard = true;
        public bool Mustard
        {
            get { return mustard; }
            set
            {
                mustard = value;
                NotifyPropertyChanged("Mustard");
            }
        }

        /// <summary>
        /// If the Dakota Double Burger comes with pickle
        /// </summary>
        private bool pickle = true;
        public bool Pickle
        {
            get { return pickle; }
            set
            {
                pickle = value;
                NotifyPropertyChanged("Pickle");
            }
        }

        /// <summary>
        /// If the Dakota Double Burger comes with cheese
        /// </summary>
        private bool cheese = true;
        public bool Cheese
        {
            get { return cheese; }
            set
            {
                cheese = value;
                NotifyPropertyChanged("Cheese");
            }
        }

        /// <summary>
        /// If the Dakota Double Burger comes with tomato
        /// </summary>
        private bool tomato = true;
        public bool Tomato
        {
            get { return tomato; }
            set
            {
                tomato = value;
                NotifyPropertyChanged("Tomato");
            }
        }

        /// <summary>
        /// If the Dakota Double Burger comes with lettuce
        /// </summary>
        private bool lettuce = true;
        public bool Lettuce
        {
            get { return lettuce; }
            set
            {
                lettuce = value;
                NotifyPropertyChanged("Lettuce");
            }
        }

        /// <summary>
        /// If the Dakota Double Burger comes with mayo
        /// </summary>
        private bool mayo = true;
        public bool Mayo
        {
            get { return mayo; }
            set
            {
                mayo = value;
                NotifyPropertyChanged("Mayo");
            }
        }

        /// <summary>
        /// The price of the Dakota Double Burger
        /// </summary>
        public override double? Price
        {
            get
            {
                return 5.20;
            }
        }

        /// <summary>
        /// The calories of the Dakota Double Burger
        /// </summary>
        public override uint? Calories
        {
            get
            {
                return 464;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of the Dakota Double Burger
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                var instructions = new List<string>();

                if (!Bun) instructions.Add("hold bun");
                if (!Ketchup) instructions.Add("hold ketchup");
                if (!Mustard) instructions.Add("hold mustard");
                if (!Pickle) instructions.Add("hold pickle");
                if (!Cheese) instructions.Add("hold cheese");
                if (!Tomato) instructions.Add("hold tomato");
                if (!Lettuce) instructions.Add("hold lettuce");
                if (!Mayo) instructions.Add("hold mayo");

                return instructions;
            }
        }

        /// <summary>
        /// Returns the name of the Dakota Double Burger
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Dakota Double Burger";
        }
    }
}
