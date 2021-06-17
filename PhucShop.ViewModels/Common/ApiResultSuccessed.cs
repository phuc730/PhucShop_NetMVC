using System;
using System.Collections.Generic;
using System.Text;

namespace PhucShop.ViewModels.Common
{
    public class ApiResultSuccessed<T> : ApiResult<T>
    {
        public ApiResultSuccessed(T resultObj)
        {
            IsSuccessed = true;
            ResultObj = resultObj;
        }

        public ApiResultSuccessed()
        {
            IsSuccessed = true;
        }
    }
}