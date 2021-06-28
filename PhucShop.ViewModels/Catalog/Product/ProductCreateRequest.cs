using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhucShop.ViewModels.Catalog.Products
{
    public class ProductCreateRequest
    {
        public decimal Price { set; get; }
        public decimal OriginalPrice { set; get; }
        public int Stock { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Details { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public bool? IsFeature { get; set; }

        public string SeoAlias { get; set; }
        public string LanguageId { set; get; }
        public int CategoryId { get; set; }
        public IFormFile ThumbnailImage { get; set; }
    }
}