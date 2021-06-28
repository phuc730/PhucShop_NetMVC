using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PhucShop.ViewModels.Catalog.Category;
using PhucShop.ViewModels.Common;
using PhucShop.ViewModels.Utilities.Slides;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PhucShop.ApiIntegration
{
    public class SlideApiClient : BaseApiClient, ISlideApiClient
    {
        public SlideApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration,
           IHttpContextAccessor httpContextAccessor)
           : base(httpClientFactory, httpContextAccessor, configuration) { }

        public async Task<List<SlideViewModel>> GetAll()
        {
            return await GetListAsync<SlideViewModel>("/api/slides");
        }
    }
}