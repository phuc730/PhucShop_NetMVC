using PhucShop.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhucShop.Application.Catalog.Products.Dtos.Manage
{
    public class ProductPagingRequest : PagingRequestBase
    {
        public string KeyWord { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
