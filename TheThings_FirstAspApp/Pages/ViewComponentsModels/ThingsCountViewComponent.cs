using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheThings.Data.Interfaces;

namespace TheThings_FirstAspApp.Pages.ViewComponents
{
    public class ThingsCountViewComponent : ViewComponent
    {
        private readonly IThingsRepository thingsRepository;

        public ThingsCountViewComponent(IThingsRepository thingsRepository)
        {
            this.thingsRepository = thingsRepository;
        }

        public IViewComponentResult Invoke()
        {
            var count = thingsRepository.CountThings();
            // metodę View można przeciążyć i podać nazwę konkretnego Componentu do wyrenderowania znajdującego się w folderze pod nazwą ThingsCount (Components/ThingsCount
            // jeżeli nie poda się nazwy zostanei wyrenderowany Default

            // dodatkowo trzeba dodać do _ViewImports: "@addTagHelper *, TheThings_FirstAspApp" aby można było użyć taghelpera <vc:[nazwa komponentu]>
            return View(count);
        }
    }
}
