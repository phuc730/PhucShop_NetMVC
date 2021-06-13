﻿using Microsoft.AspNetCore.Mvc;
using PhucShop.ApiIntegration;
using PhucShop.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhucShop.AdminApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserApiClient _userApiClient;

        public UserController(IUserApiClient userApiClient)
        {
            _userApiClient = userApiClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(ModelState);
            }

            var token = await _userApiClient.Authenticate(request);
            return View(token);
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
    }
}