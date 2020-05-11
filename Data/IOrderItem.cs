using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    public interface IOrderItem
    {
        /// <summary>
        /// The price for the order item
        /// </summary>
        double Price { get; }

        /// <summary>
        /// The calories for the order item
        /// </summary>
        uint Calories { get; }

        string Type { get; }

        /// <summary>
        /// The special instruction for the order item
        /// </summary>
        IEnumerable<string> SpecialInstructions { get; }
    }
}
