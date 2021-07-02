using PhucShop.ViewModels.Dtos;

namespace PhucShop.ViewModels.Catalog.Products
{
    public class PublicProductPagingRequest : PagingRequestBase
    {
        public int? CategoryId { get; set; }
    }
}