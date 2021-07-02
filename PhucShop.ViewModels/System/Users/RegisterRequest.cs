using System;
using System.ComponentModel.DataAnnotations;

namespace PhucShop.ViewModels.System.Users
{
    public class RegisterRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string PassWord { get; set; }

        [DataType(DataType.Password)]
        public string ConfirmPassWord { get; set; }
    }
}