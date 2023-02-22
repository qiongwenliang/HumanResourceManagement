﻿using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using Microsoft.AspNetCore.Mvc;

namespace HRM.WebMVCApp.Controllers
{
    public class EmployeeStatusController : Controller
    {
        private readonly IEmployeeStatusServiceAsync employeeStatusServiceAsync;

        public EmployeeStatusController(IEmployeeStatusServiceAsync _employeeStatusServiceAsync)
        {
            employeeStatusServiceAsync = _employeeStatusServiceAsync;
        }

        public async Task<IActionResult> Index()
        {
            var employeeStatusCollection = await employeeStatusServiceAsync.GetAllEmployeeStatusAsync();
            return View(employeeStatusCollection);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeStatusRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await employeeStatusServiceAsync.AddEmployeeStatusAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await employeeStatusServiceAsync.GetEmployeeStatusByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeStatusRequestModel model)
        {
            try
            {
                await employeeStatusServiceAsync.UpdateEmployeeStatusAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await employeeStatusServiceAsync.GetEmployeeStatusByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EmployeeStatusResponseModel model)
        {
            await employeeStatusServiceAsync.DeleteEmployeeStatusAsync(model.Id);
            return RedirectToAction("Index");

        }
    }
}