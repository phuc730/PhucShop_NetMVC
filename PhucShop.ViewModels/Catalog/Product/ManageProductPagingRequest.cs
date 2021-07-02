using PhucShop.ViewModels.Dtos;

namespace PhucShop.ViewModels.Catalog.Products
{
    public class ManageProductPagingRequest : PagingRequestBase
    {
        public string KeyWord { get; set; }
        public string LanguageId { get; set; }
        public int? CategoryId { get; set; }
    }
}