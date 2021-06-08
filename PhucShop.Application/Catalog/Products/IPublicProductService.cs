
using PhucShop.ViewModels.Catalog.Products.Dtos;
using PhucShop.ViewModels.Catalog.Products.Dtos.Public;
using PhucShop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhucShop.Application.Catalog.Products
{
    public interface IPublicProductService
    {
       Task<PageResult<ProductViewModel>> GetAllByCategoryId(ProductPagingRequest request);
    }
}
