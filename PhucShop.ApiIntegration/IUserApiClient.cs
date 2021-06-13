using PhucShop.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhucShop.ApiIntegration
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
    }
}