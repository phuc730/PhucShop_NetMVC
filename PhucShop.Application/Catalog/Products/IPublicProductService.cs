using PhucShop.Application.Catalog.Products.Dtos;
using PhucShop.Application.Catalog.Products.Dtos.Public;
using PhucShop.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhucShop.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        PageResult<ProductViewModel> GetAllByCategoryId(ProductPagingRequest request);
    }
}
