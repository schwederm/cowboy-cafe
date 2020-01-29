using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    public class AngryChicken
    {
        /// <summary>
        /// If the sandwich comes with bread
        /// </summary>
        public bool Bread { get; set; } = true;

        /// <summary>
        /// If the sandwich comes with a pickle
        /// </summary>
        public bool Pickle { get; set; } = true;

        /// <summary>
        /// The price of the sandwich
        /// </summary>
        public double Price
        {
            get
            {
                return 6.10;
            }
        }

        /// <summary>
        /// The calories of the sandwich
        /// </summary>
        public uint Calories
        {
            get
            {
                return 171;
            }
        }

        /// <summary>
        /// Special instructions for the preparation of the sandwich
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                var instructions = new List<string>();

                if (!bread) instructions.Add("hold bread");
                if (!pickle) instructions.Add("hold sour pickle");

                return instructions;
            }
        }
    }
}
