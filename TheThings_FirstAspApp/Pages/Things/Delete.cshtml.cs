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
    public class DeleteModel : PageModel
    {
        private readonly IThingsRepository thingsRepository;

        [BindProperty]
        public Thing Thing { get; set; }

        public DeleteModel(IThingsRepository thingsRepository)
        {
            this.thingsRepository = thingsRepository;
        }

        public IActionResult OnGet(int thingId)
        {
            Thing = thingsRepository.GetById(thingId);
            if (Thing == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int thingId)
        {
            var deletedThing = thingsRepository.Delete(thingId);
            thingsRepository.SaveChanges();
            if(deletedThing == null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"You deleted {Thing.Name}.";
            return RedirectToPage("./List");
        }
    }
}