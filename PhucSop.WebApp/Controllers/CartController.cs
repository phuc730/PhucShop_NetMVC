using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PhucShop.ApiIntegration;
using PhucShop.Utilities.Constants;
using PhucShop.ViewModels.Sales;
using PhucSop.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhucSop.WebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductApiClient _productApiClient;

        public CartController(IProductApiClient productApiClient)
        {
            _productApiClient = productApiClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddToCart(int id, string languageId)
        {
            var product = await _productApiClient.GetById(id, languageId);

            //lay cac gia tri trong cartSession cua session hien tai(neu hien tai khong co session nao thi se SetString session ben duoi)
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);

            List<CartViewModel> currentCart = new List<CartViewModel>();

            if (session != null)
            {
                currentCart = JsonConvert.DeserializeObject<List<CartViewModel>>(session);
            }

            var quantity = 1;

            if (currentCart.Any(x => x.ProductId == id))
            {
                quantity = currentCart.First(x => x.ProductId == id).Quantity + 1;
            }

            var cartViewModel = new CartViewModel()
            {
                ProductId = id,
                Description = product.Description,
                Image = product.ThumbnailImage,
                Name = product.Name,
                Quantity = quantity,
                Price = product.Price
            };

            if (currentCart == null) currentCart = new List<CartViewModel>();

            currentCart.Add(cartViewModel);

            foreach (var item in currentCart)
            {
                var quantityBeforeAdd = currentCart.First(x => x.ProductId == item.ProductId).Quantity;
                var quantityAfterAdd = currentCart.Last(x => x.ProductId == item.ProductId).Quantity;
                if (quantityAfterAdd > quantityBeforeAdd)
                {
                    currentCart.Remove(item);
                    break;
                }
            }

            // neu o tren khong co session nao thi o day se tao ra 1 cartSession va truyen data vao
            HttpContext.Session.SetString(SystemConstants.CartSession, JsonConvert.SerializeObject(currentCart));
            return Ok(currentCart);
        }

        [HttpGet]
        public IActionResult GetListItems()
        {
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);

            List<CartViewModel> currentCart = new List<CartViewModel>();

            if (session != null)
            {
                currentCart = JsonConvert.DeserializeObject<List<CartViewModel>>(session);
            }
            return Ok(currentCart);
        }

        public IActionResult UpdateCart(int id, int quantity)
        {
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);

            List<CartViewModel> currentCart = new List<CartViewModel>();

            if (session != null)
            {
                currentCart = JsonConvert.DeserializeObject<List<CartViewModel>>(session);
            }

            foreach (var item in currentCart)
            {
                if (item.ProductId == id)
                {
                    if (quantity == 0)
                    {
                        currentCart.Remove(item);
                        break;
                    }
                    item.Quantity = quantity;
                }
            }

            HttpContext.Session.SetString(SystemConstants.CartSession, JsonConvert.SerializeObject(currentCart));
            return Ok(currentCart);
        }

        [HttpGet]
        public IActionResult CheckOutCart()
        {
            return View(GetCheckoutViewModel());
        }

        [HttpPost]
        public IActionResult CheckOutCart(CheckoutViewModel request)
        {
            var model = GetCheckoutViewModel();
            var orderDetails = new List<OrderViewModel>();
            foreach (var item in model.CartItems)
            {
                orderDetails.Add(new OrderViewModel()
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                });
            }

            var checkoutRequest = new CheckoutRequest()
            {
                Address = request.CheckoutModel.Address,
                Email = request.CheckoutModel.Email,
                Name = request.CheckoutModel.Name,
                PhoneNumber = request.CheckoutModel.PhoneNumber,
                OrderDetails = orderDetails
            };
            TempData["SuccessMsg"] = "Order success";
            return View(GetCheckoutViewModel());
        }

        private CheckoutViewModel GetCheckoutViewModel()
        {
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);

            List<CartViewModel> currentCart = new List<CartViewModel>();

            if (session != null)
            {
                currentCart = JsonConvert.DeserializeObject<List<CartViewModel>>(session);
            }

            var checkoutViewModel = new CheckoutViewModel()
            {
                CartItems = currentCart,
                CheckoutModel = new CheckoutRequest()
            };
            return checkoutViewModel;
        }
    }
}