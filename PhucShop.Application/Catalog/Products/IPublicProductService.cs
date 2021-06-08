
using PhucShop.ViewModels.Catalog.Products;
using PhucShop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhucShop.Application.Catalog.Products
{
    public interface IPublicProductService
    {
       Task<PageResult<ProductViewModel>> GetAllByCategoryId(PublicProductPagingRequest request);

        Task<List<ProductViewModel>> GetAll(string languageId);
    }
}
