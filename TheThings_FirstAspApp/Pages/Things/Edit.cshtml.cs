using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheThings.Data.Interfaces;
using TheThings.Models;

namespace TheThings_FirstAspApp.Pages.Things
{
    public class EditModel : PageModel
    {
        private readonly IThingsRepository thingsRepo;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Thing Thing { get; set; }

        public IEnumerable<SelectListItem> Types { get; set; }

        public EditModel(IThingsRepository thingsRepo, IHtmlHelper htmlHelper)
        {
            this.thingsRepo = thingsRepo;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? thingId)
        {
            Types = htmlHelper.GetEnumSelectList<ThingType>();
            if (thingId.HasValue)
            {
                Thing = thingsRepo.GetById(thingId.Value);
            }
            else
            {
                Thing = new Thing();
            }
            
            if(Thing == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            Types = htmlHelper.GetEnumSelectList<ThingType>();
            if (ModelState.IsValid)
            {
                if(Thing.Id == 0)
                {
                    thingsRepo.Add(Thing);
                    TempData["Message"] = "Thing added";
                }
                else
                {
                    thingsRepo.Update(Thing);
                    TempData["Message"] = "Thing updated";
                }
                thingsRepo.SaveChanges();
                return RedirectToPage("./Detail", new { thingId = Thing.Id });
            }
            else
            {
                return Page();
            }
        }
    }
}