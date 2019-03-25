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
    public class DetailModel : PageModel
    {
        private readonly IThingsRepository thingsRepo;

        [TempData]
        public string Message { get; set; }

        public DetailModel(IThingsRepository thingsRepo)
        {
            this.thingsRepo = thingsRepo;
        }

        public Thing Thing { get; set; }

        public IActionResult OnGet(int thingId)
        {
            Thing = thingsRepo.GetById(thingId);
            if (Thing == null)
            {
                return RedirectToPage("NotFound");
            }
            return Page();
        }
    }
}