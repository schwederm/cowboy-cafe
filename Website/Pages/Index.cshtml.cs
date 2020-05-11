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
        public IEnumerable<IOrderItem> Menu { get; protected set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerms { get; set; }

        [BindProperty(SupportsGet = true)]
        public string[] TypesOfItems { get; set; }

        [BindProperty(SupportsGet = true)]
        public uint? CaloriesMin { get; set; }

        [BindProperty(SupportsGet = true)]
        public uint? CaloriesMax { get; set; }

        [BindProperty(SupportsGet = true)]
        public double? PriceMin { get; set; }

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
            Menu = CCMenu.Search(SearchTerms);
            Menu = CCMenu.FilterByCategory(Menu, TypesOfItems);
            Menu = CCMenu.FilterByCalories(Menu, CaloriesMin, CaloriesMax);
            Menu = CCMenu.FilterByPrice(Menu, PriceMin, PriceMax);
        }
    }
}
