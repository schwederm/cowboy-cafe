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
        /// The special instruction for the order item
        /// </summary>
        List<string> SpecialInstructions { get; }
    }
}
