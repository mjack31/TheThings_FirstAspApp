using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheThings.Data.Interfaces;
using TheThings.Models;

namespace TheThings_FirstAspApp.Pages.Things
{
    public class ListModel : PageModel
    {
        private readonly IThingsRepository thingsRepository;
        public List<Thing> Things { get; set; }

        public ListModel(IThingsRepository thingsRepository)
        {
            this.thingsRepository = thingsRepository;
        }

        public void OnGet()
        {
            Things = thingsRepository.GetAll();
        }
    }
}