using PhucShop.Application.Catalog.Products.Dtos;
using PhucShop.Application.Catalog.Products.Dtos.Manage;
using PhucShop.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhucShop.Application.Catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int ProductId);

        Task<bool> UpdatePrice(int productId, decimal newPrice);

        Task<bool> UpdateStock(int productId, int addedQuantity);

        Task AddViewcount(int productId);

        Task<PageResult<ProductViewModel>> GetAllPaging(ProductPagingRequest request);
    }
}
