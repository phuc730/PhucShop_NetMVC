using PhucShop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhucShop.ViewModels.Dtos
{
    public class PagingRequestBase
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}