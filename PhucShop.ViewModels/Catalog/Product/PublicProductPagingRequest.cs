using PhucShop.ViewModels.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhucShop.ViewModels.Catalog.Products
{
    public class PublicProductPagingRequest : PagingRequestBase
    {
        public int? CategoryId { get; set; }
    }
}
