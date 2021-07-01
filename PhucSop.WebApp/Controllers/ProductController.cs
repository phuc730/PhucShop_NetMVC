using Microsoft.AspNetCore.Mvc;
using PhucShop.ApiIntegration;
using PhucShop.ViewModels.Catalog.Product;
using PhucShop.ViewModels.Catalog.Products;
using PhucSop.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhucSop.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        private readonly ICategoryApiClient _categoryApiClient;

        public ProductController(IProductApiClient productApiClient, ICategoryApiClient categoryApiClient)
        {
            _productApiClient = productApiClient;
            _categoryApiClient = categoryApiClient;
        }

        public async Task<IActionResult> Detail(int id, string culture)
        {
            var product = await _productApiClient.GetById(id, culture);
            var category = await _categoryApiClient.GetById(culture, id);
            var productViewModel = new ProductDetailViewModel()
            {
                Category = category,
                Product = product
            };
            return View(productViewModel);
        }

        public async Task<IActionResult> Category(int id, string culture, int pageIndex = 1, int pageSize = 10)
        {
            var products = await _productApiClient.GetPagings(new ManageProductPagingRequest()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                LanguageId = culture,
                CategoryId = id
            });
            return View(new ProductCategoryViewModel()
            {
                Category = await _categoryApiClient.GetById(culture, id),
                Products = products
            });
        }
    }
}