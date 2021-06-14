using PhucShop.ViewModels.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhucShop.ViewModels.System.Users
{
    public class UserPagingRequest : PagingRequestBase
    {
        public string KeyWord { get; set; }
    }
}