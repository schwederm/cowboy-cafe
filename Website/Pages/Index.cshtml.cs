using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using CowboyCafe.Data;
using CCMenu = CowboyCafe.Data.Menu;

namespace Website.Pages
{
    public class IndexModel : PageModel
    {
        /// <summary>
        /// Holds the filtered Menu items
        /// </summary>
        public IEnumerable<IOrderItem> Menu { get; protected set; }

        /// <summary>
        /// Holds the Jerked Soda flavors
        /// </summary>
        public IEnumerable<string> Flavors = new List<string>
        {
            "Birch Beer",
            "Cream Soda",
            "Orange Soda",
            "Root Beer",
            "Sarsparilla"
        };

        /// <summary>
        /// Holds the search terms
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string SearchTerms { get; set; }

        /// <summary>
        /// Holds the types of items
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string[] TypesOfItems { get; set; }

        /// <summary>
        /// Holds the minimum calories
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public uint? CaloriesMin { get; set; }

        /// <summary>
        /// Holds the maximum calories
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public uint? CaloriesMax { get; set; }

        /// <summary>
        /// Holds the minimum price
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public double? PriceMin { get; set; }

        /// <summary>
        /// Holds the maximum price
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public double? PriceMax { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Grabs the Menu for Cowboy Cafe on each reload
        /// </summary>
        public void OnGet()
        {
            // Filters the Menu variable with Where statements
            Menu = CCMenu.All();
            if (SearchTerms != null)
            {
                Menu = Menu.Where(menu =>
                    menu.ToString() != null &&
                    menu.ToString().Contains(SearchTerms, StringComparison.CurrentCultureIgnoreCase)
                    );
            }
            if (TypesOfItems != null && TypesOfItems.Length != 0)
            {
                Menu = Menu.Where(menu =>
                    menu.Type != null &&
                    TypesOfItems.Contains(menu.Type)
                    );
            }
            if (CaloriesMin != null || CaloriesMax != null)
            {
                Menu = Menu.Where(menu =>
                    menu.Calories != null &&
                    menu.Calories >= CaloriesMin ||
                    menu.Calories <= CaloriesMax
                    );
            }
            if (PriceMin != null || PriceMax != null)
            {
                Menu = Menu.Where(menu =>
                    menu.Price != null &&
                    menu.Price >= PriceMin ||
                    menu.Price <= PriceMax
                    );
            }
        }
    }
}
