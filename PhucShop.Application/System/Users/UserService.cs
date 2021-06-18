using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PhucShop.Data.Entities;
using PhucShop.ViewModels.Common;
using PhucShop.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PhucShop.Application.System.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;

        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager
            , IConfiguration config, RoleManager<AppRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _config = config;
        }

        public async Task<ApiResult<string>> Authencate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) return new ApiResultError<string>("Username is not exists!");

            var result = await _signInManager.PasswordSignInAsync(user, request.PassWord, request.RememberMe, true);
            if (!result.Succeeded)
            {
                return new ApiResultError<string>("Login fail!");
            }

            var roles = _userManager.GetRolesAsync(user);
            // dang nhap thanh cong thi se lay ra email, firstName va cac role cua user
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Role, string.Join(";", roles)),
                new Claim(ClaimTypes.Name, request.UserName)
            };
            // tao ra token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            return new ApiResultSuccessed<string>(new JwtSecurityTokenHandler().WriteToken(token));
        }

        public async Task<ApiResult<bool>> Delete(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                return new ApiResultError<bool>("User not exists");
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return new ApiResultSuccessed<bool>();
            }

            return new ApiResultError<bool>("Delete fail!");
        }

        public async Task<ApiResult<UserViewModel>> GetById(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                return new ApiResultError<UserViewModel>("User not exists");
            }

            var userViewModel = new UserViewModel()
            {
                Email = user.Email,
                Dob = user.Dob,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Id = user.Id,
                UserName = user.UserName
            };

            return new ApiResultSuccessed<UserViewModel>(userViewModel);
        }

        public async Task<ApiResult<PageResult<UserViewModel>>> GetUsersPaging(UserPagingRequest request)
        {
            var query = _userManager.Users;

            if (!string.IsNullOrEmpty(request.KeyWord))
            {
                // contains su dung nhu like
                query = query.Where(x => x.UserName.Contains(request.KeyWord) ||
                   x.PhoneNumber.Contains(request.KeyWord));
            }

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new UserViewModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Dob = x.Dob,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    UserName = x.UserName
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PageResult<UserViewModel>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return new ApiResultSuccessed<PageResult<UserViewModel>>(pagedResult);
        }

        public async Task<ApiResult<bool>> Register(RegisterRequest request)
        {
            var userName = await _userManager.FindByNameAsync(request.UserName);
            if (userName != null)
            {
                return new ApiResultError<bool>("Username is exists");
            }

            var Email = await _userManager.FindByEmailAsync(request.Email);
            if (Email != null)
            {
                return new ApiResultError<bool>("Email is exists");
            }

            var user = new AppUser()
            {
                UserName = request.UserName,
                Dob = request.Dob,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, request.PassWord);
            if (result.Succeeded)
            {
                return new ApiResultSuccessed<bool>();
            }

            return new ApiResultError<bool>("Register unsuccess!");
        }

        public async Task<ApiResult<bool>> Update(Guid id, UserUpdateRequest request)
        {
            var Email = await _userManager.Users.AnyAsync(x => x.Email == request.Email && x.Id != id);
            if (Email)
            {
                return new ApiResultError<bool>("Email is exists");
            }
            var user = await _userManager.FindByIdAsync(id.ToString());

            user.Dob = request.Dob;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.PhoneNumber = request.PhoneNumber;
            user.Email = request.Email;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new ApiResultSuccessed<bool>();
            }

            return new ApiResultError<bool>("Update unsuccess!");
        }
    }
}