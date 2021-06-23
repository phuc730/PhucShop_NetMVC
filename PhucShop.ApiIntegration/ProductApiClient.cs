using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PhucShop.ViewModels.Catalog.Products;
using PhucShop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PhucShop.ApiIntegration
{
    public class ProductApiClient : BaseApiClient, IProductApiClient
    {
        public ProductApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor) : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<PageResult<ProductViewModel>> GetPagings(ManageProductPagingRequest request)
        {
            var data = await base.GetAsync<PageResult<ProductViewModel>>
               ($"/api/products/pagings?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyWord={request.KeyWord}"+
                $"&languageId={request.LanguageId}");
            return data;
        }
    }
}