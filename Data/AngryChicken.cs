﻿/*
 *  Author: Matt Schweder
 *  Class Name: AngryChicken.cs
 *  Purpose: This class holds all the optional ingredients, price, calories, and special instructions for the Angry Chicken sandwich.
*/


using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    public class AngryChicken : Entree
    {
        /// <summary>
        /// If the Angry Chicken comes with bread
        /// </summary>
        private bool bread = true;
        public bool Bread
        {
            get { return bread; }
            set
            {
                bread = value;
                NotifyPropertyChanged("Bread");
            }
        }

        /// <summary>
        /// If the Angry Chicken comes with a pickle
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
        /// The price of the Angry Chicken
        /// </summary>
        public override double? Price
        {
            get
            {
                return 5.99;
            }
        }

        /// <summary>
        /// The calories of the Angry Chicken
        /// </summary>
        public override uint? Calories
        {
            get
            {
                return 190;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of the Angry Chicken
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                var instructions = new List<string>();

                if (!Bread) instructions.Add("hold bread");
                if (!Pickle) instructions.Add("hold pickle");

                return instructions;
            }
        }

        /// <summary>
        /// Returns the name of the Angry Chicken
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Angry Chicken";
        }
    }
}