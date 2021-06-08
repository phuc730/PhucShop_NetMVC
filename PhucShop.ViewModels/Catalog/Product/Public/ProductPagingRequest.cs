using PhucShop.ViewModels.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhucShop.ViewModels.Catalog.Products.Dtos.Public
{
    public class ProductPagingRequest : PagingRequestBase
    {
        public int? CategoryId { get; set; }
    }
}
