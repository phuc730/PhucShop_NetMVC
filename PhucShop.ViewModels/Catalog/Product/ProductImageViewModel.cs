using System;
using System.Collections.Generic;
using System.Text;

namespace PhucShop.ViewModels.Catalog.Product
{
    public class ProductImageViewModel
    {
        public int Id { get; set; }
        public string PathFile { get; set; }
        public bool IsDefault { get; set; }
        public long FileLenght { get; set; }
    }
}
