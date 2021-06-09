using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhucShop.Application.Catalog.Products;
using PhucShop.ViewModels.Catalog.ProductImage;
using PhucShop.ViewModels.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhucShop.BackEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IPublicProductService _publicProductService;

        private readonly IManageProductService _manageProductService;

        public ProductsController(IPublicProductService publicProductService, IManageProductService manageProductService)
        {
            _publicProductService = publicProductService;
            _manageProductService = manageProductService;
        }

        [HttpGet("{languageId}")]
        public async Task<IActionResult> GetAllPagging(string languageId, [FromQuery] PublicProductPagingRequest request)
        {
            var product = await _publicProductService.GetAllByCategoryId(languageId, request);
            return Ok(product);
        }

        [HttpGet("{productId}/{languageId}")]
        public async Task<IActionResult> GetById(int productId, string languageId)
        {
            var product = await _manageProductService.GetById(productId, languageId);
            if (product == null)
                return BadRequest("Cannot find product!");
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            //modelState la kiem tra co so du lieu nhap vao
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productId = await _manageProductService.Create(request);
            if (productId == 0)
            {
                return BadRequest();
            }

            var product = await _manageProductService.GetById(productId, request.LanguageId);

            return CreatedAtAction(nameof(GetById), new { id = productId }, product);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
        {
            //modelState la kiem tra co so du lieu nhap vao
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _manageProductService.Update(request);
            if (result == 0)
            {
                return BadRequest();
            }

            //var product = await _manageProductService.GetById(result);

            return Ok();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {
            var result = await _manageProductService.Delete(productId);
            if (result == 0)
            {
                return BadRequest();
            }

            return Ok();
        }

        //su dung Patch de update 1 phan cua bang Product
        [HttpPatch("price/{productId}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice([FromQuery] int productId, decimal newPrice)
        {
            var result = await _manageProductService.UpdatePrice(productId, newPrice);
            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("{productId}/images/{imageId}")]
        public async Task<IActionResult> GetImageById(int productId, int imageId)
        {
            var productImage = await _manageProductService.GetImageById(imageId);
            if (productImage == null)
                return BadRequest("Cannot find Image!");
            return Ok(productImage);
        }

        [HttpPost("{productId}/images")]
        public async Task<IActionResult> AddImage(int productId, [FromForm] ProductImageCreateRequest request)
        {
            //modelState la kiem tra co so du lieu nhap vao
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var imageId = await _manageProductService.AddImage(productId, request);
            if (imageId == 0)
            {
                return BadRequest();
            }

            var image = await _manageProductService.GetImageById(imageId);

            return CreatedAtAction(nameof(GetImageById), new { id = imageId }, image);
        }

        [HttpPut("{productId}/images/{imageId}")]
        public async Task<IActionResult> UpdateImage(int imageId, [FromForm] ProductImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _manageProductService.UpdateImage(imageId, request);
            if (result == 0)
                return BadRequest();

            return Ok();
        }

        [HttpDelete("{productId}/images/{imageId}")]
        public async Task<IActionResult> RemoveImage(int imageId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _manageProductService.DeleteImage(imageId);
            if (result == 0)
                return BadRequest();

            return Ok();
        }
    }
}