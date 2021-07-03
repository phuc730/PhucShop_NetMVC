using PhucShop.ViewModels.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhucSop.WebApp.Models
{
    public class CheckoutViewModel
    {
        public List<CartViewModel> CartItems { get; set; }

        public CheckoutRequest CheckoutModel { get; set; }
    }
}