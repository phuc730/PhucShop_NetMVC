using System;
using System.Collections.Generic;
using System.Text;

namespace PhucShop.Utilities.Exceptions
{
    public class pShopException : Exception
    {
        public pShopException()
        {

        }

        public pShopException(string message) : base(message)
        {

        }

        public pShopException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
