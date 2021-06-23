using PhucShop.ViewModels.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhucShop.ViewModels.Catalog.Products
{
    public class ManageProductPagingRequest : PagingRequestBase
    {
        public string KeyWord { get; set; }
        public List<int> CategoryIds { get; set; }
        public string LanguageId { get; set; }
    }
}