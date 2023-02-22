﻿using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using Microsoft.AspNetCore.Mvc;

namespace HRM.WebMVCApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServiceAsync userServiceAsync;

        public UserController(IUserServiceAsync _userServiceAsync)
        {
            userServiceAsync = _userServiceAsync;
        }

        public async Task<IActionResult> Index()
        {
            var userCollection = await userServiceAsync.GetAllUserAsync();
            return View(userCollection);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await userServiceAsync.AddUserAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await userServiceAsync.GetUserByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserRequestModel model)
        {
            try
            {
                await userServiceAsync.UpdateUserAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await userServiceAsync.GetUserByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UserResponseModel model)
        {
            await userServiceAsync.DeleteUserAsync(model.Id);
            return RedirectToAction("Index");

        }
    }
}
