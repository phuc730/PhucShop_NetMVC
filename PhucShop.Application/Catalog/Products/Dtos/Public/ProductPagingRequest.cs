using PhucShop.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhucShop.Application.Catalog.Products.Dtos.Public
{
    public class ProductPagingRequest : PagingRequestBase
    {
        public int? CategoryId { get; set; }
    }
}
