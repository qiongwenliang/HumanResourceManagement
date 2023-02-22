﻿using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using Microsoft.AspNetCore.Mvc;

namespace HRM.WebMVCApp.Controllers
{
    public class JobRequirementController : Controller
    {
        private readonly IJobRequirementServiceAsync jobRequirementServiceAsync;

        public JobRequirementController(IJobRequirementServiceAsync _jobRequirementServiceAsync)
        {
            jobRequirementServiceAsync = _jobRequirementServiceAsync;
        }

        public async Task<IActionResult> Index()
        {
            var jobRequirementCollection = await jobRequirementServiceAsync.GetAllJobRequirementAsync();
            return View(jobRequirementCollection);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(JobRequirementRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await jobRequirementServiceAsync.AddJobRequirementAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await jobRequirementServiceAsync.GetJobRequirementByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(JobRequirementRequestModel model)
        {
            try
            {
                await jobRequirementServiceAsync.UpdateJobRequirementAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await jobRequirementServiceAsync.GetJobRequirementByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(JobRequirementResponseModel model)
        {
            await jobRequirementServiceAsync.DeleteJobRequirementAsync(model.Id);
            return RedirectToAction("Index");

        }
    }
}