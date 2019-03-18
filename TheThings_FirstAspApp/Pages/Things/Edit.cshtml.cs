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

        public void OnGet(int thingId)
        {
            Types = htmlHelper.GetEnumSelectList<ThingType>();
            Thing = thingsRepo.GetById(thingId);
        }
    }
}