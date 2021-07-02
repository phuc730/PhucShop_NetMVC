using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhucSop.WebApp.Models
{
    public class CartViewModel
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }
    }
}