using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using Microsoft.AspNetCore.Mvc;

namespace HRM.WebMVCApp.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleServiceAsync roleServiceAsync;

        public RoleController(IRoleServiceAsync _roleServiceAsync)
        {
            roleServiceAsync = _roleServiceAsync;
        }

        public async Task<IActionResult> Index()
        {
            var roleCollection = await roleServiceAsync.GetAllRoleAsync();
            return View(roleCollection);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await roleServiceAsync.AddRoleAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await roleServiceAsync.GetRoleByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoleRequestModel model)
        {
            try
            {
                await roleServiceAsync.UpdateRoleAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await roleServiceAsync.GetRoleByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RoleResponseModel model)
        {
            await roleServiceAsync.DeleteRoleAsync(model.Id);
            return RedirectToAction("Index");

        }
    }
}
