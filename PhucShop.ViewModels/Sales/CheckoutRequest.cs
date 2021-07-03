using System;
using System.Collections.Generic;
using System.Text;

namespace PhucShop.ViewModels.Sales
{
    public class CheckoutRequest
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public List<OrderViewModel> OrderDetails { get; set; } = new List<OrderViewModel>();
    }
}