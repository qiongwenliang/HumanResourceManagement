using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using HRM.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace HRM.WebMVCApp.Controllers
{
    public class EmployeeRoleController : Controller
    {
        private readonly IEmployeeRoleServiceAsync employeeRoleServiceAsync;

        public EmployeeRoleController(IEmployeeRoleServiceAsync _employeeRoleServiceAsync)
        {
            employeeRoleServiceAsync = _employeeRoleServiceAsync;
        }

        public async Task<IActionResult> Index()
        {
            var employeeRoleCollection = await employeeRoleServiceAsync.GetAllEmployeeRoleAsync();
            return View(employeeRoleCollection);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeRoleRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await employeeRoleServiceAsync.AddEmployeeRoleAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await employeeRoleServiceAsync.GetEmployeeRoleByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeRoleRequestModel model)
        {
            try
            {
                await employeeRoleServiceAsync.UpdateEmployeeRoleAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await employeeRoleServiceAsync.GetEmployeeRoleByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EmployeeRoleResponseModel model)
        {
            await employeeRoleServiceAsync.DeleteEmployeeRoleAsync(model.Id);
            return RedirectToAction("Index");

        }
    }
}
