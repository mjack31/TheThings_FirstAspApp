using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using TheThings.Data.Interfaces;
using TheThings.Models;

namespace TheThings_FirstAspApp.Pages.Things
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IThingsRepository thingsRepository;

        public string ConfigMsg { get; set; }
        public IEnumerable<Thing> Things { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, IThingsRepository thingsRepository)
        {
            this.config = config;
            this.thingsRepository = thingsRepository;
        }

        public void OnGet()
        {
            ConfigMsg = config["msg"];
            Things = thingsRepository.GetByName(SearchTerm);
        }
    }
}