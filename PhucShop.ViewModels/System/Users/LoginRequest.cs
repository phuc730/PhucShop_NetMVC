using System.ComponentModel.DataAnnotations;

namespace PhucShop.ViewModels.System.Users
{
    public class LoginRequest
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string PassWord { get; set; }

        public bool RememberMe { get; set; }
    }
}