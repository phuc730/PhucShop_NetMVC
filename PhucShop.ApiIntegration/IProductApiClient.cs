using PhucShop.ViewModels.Catalog.Products;
using PhucShop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhucShop.ApiIntegration
{
    public interface IProductApiClient
    {
        Task<PageResult<ProductViewModel>> GetPagings(ManageProductPagingRequest request);
    }
}