using Microsoft.AspNetCore.Mvc;
using PhucShop.ApiIntegration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PhucSop.WebApp.Controllers.Components
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly ICategoryApiClient _categoryApiClient;

        public SidebarViewComponent(ICategoryApiClient categoryApiClient)
        {
            _categoryApiClient = categoryApiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var item = await _categoryApiClient.GetAll(CultureInfo.CurrentCulture.Name);
            return View(item);
        }
    }
}