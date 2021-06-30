using PhucShop.ViewModels.Catalog.Product;
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

        Task<bool> CreateProduct(ProductCreateRequest request);

        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);

        Task<ProductViewModel> GetById(int id, string languageId);

        Task<List<ProductViewModel>> GetFeaturedProducts(int take, string languageId);

        Task<List<ProductViewModel>> GetLatestProducts(int take, string languageId);
    }
}