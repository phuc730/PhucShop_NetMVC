using PhucShop.ViewModels.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhucShop.ViewModels.Catalog.Products.Dtos.Manage
{
    public class ProductPagingRequest : PagingRequestBase
    {
        public string KeyWord { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
