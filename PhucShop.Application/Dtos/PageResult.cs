using System;
using System.Collections.Generic;
using System.Text;

namespace PhucShop.Application.Dtos
{
    public class PageResult<T>
    {
        public int TotalRecord { get; set; }
        public List<T> Items { get; set; }
    }
}
