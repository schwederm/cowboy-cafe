/*
 * Author: Matt Schweder
 * Class Name: TrailBurger.cs
 * Purpose: This class holds all the optional ingredients, price, calories, and special instructions for the Trail Burger
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    public class TrailBurger : Entree
    {
        /// <summary>
        /// If the Trail Burger comes with buns
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
        /// If the Trail Burger comes with ketchup
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
        /// If the Trail Burger comes with mustard
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
        /// If the Trail Burger comes with pickle
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
        /// If the Trial Burger comes with cheese
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
        /// The price of the Trail Burger
        /// </summary>
        public override double Price
        {
            get
            {
                return 4.50;
            }
        }

        /// <summary>
        /// The calories of the Trail Burger
        /// </summary>
        public override uint Calories
        {
            get
            {
                return 288;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of the Trail Burger
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

                return instructions;
            }
        }

        /// <summary>
        /// Returns the name of the Trail Burger
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Trail Burger";
        }
    }
}
