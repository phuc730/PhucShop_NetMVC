using PhucShop.Application.Catalog.Products.Dtos;
using PhucShop.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhucShop.Application.Catalog.Products
{
    public class PublicProductService : IPublicProductService
    {
        public PageResult<ProductViewModel> GetAllByCategoryId(int categoryId, int pageSize, int pageIndex)
        {
            throw new NotImplementedException();
        }
    }
}
