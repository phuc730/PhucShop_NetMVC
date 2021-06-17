using System;
using System.Collections.Generic;
using System.Text;

namespace PhucShop.ViewModels.Common
{
    public class ApiResultError<T> : ApiResult<T>
    {
        public string[] ValidationErrors { get; set; }

        public ApiResultError()
        {
        }

        public ApiResultError(string message)
        {
            IsSuccessed = false;
            Message = message;
        }

        public ApiResultError(string[] validationErrors)
        {
            IsSuccessed = false;
            ValidationErrors = validationErrors;
        }
    }
}