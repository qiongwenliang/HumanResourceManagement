using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using Microsoft.AspNetCore.Mvc;

namespace HRM.WebMVCApp.Controllers
{
    public class JobCategoryController : Controller
    {
        private readonly IJobCategoryServiceAsync jobCategoryServiceAsync;

        public JobCategoryController(IJobCategoryServiceAsync _jobCategoryServiceAsync)
        {
            jobCategoryServiceAsync = _jobCategoryServiceAsync;
        }

        public async Task<IActionResult> Index()
        {
            var jobCategoryCollection = await jobCategoryServiceAsync.GetAllJobCategoryAsync();
            return View(jobCategoryCollection);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(JobCategoryRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await jobCategoryServiceAsync.AddJobCategoryAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await jobCategoryServiceAsync.GetJobCategoryByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(JobCategoryRequestModel model)
        {
            try
            {
                await jobCategoryServiceAsync.UpdateJobCategoryAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await jobCategoryServiceAsync.GetJobCategoryByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(JobCategoryResponseModel model)
        {
            await jobCategoryServiceAsync.DeleteJobCategoryAsync(model.Id);
            return RedirectToAction("Index");

        }
    }
}