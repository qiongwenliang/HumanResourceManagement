using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using Microsoft.AspNetCore.Mvc;

namespace HRM.WebMVCApp.Controllers
{
    public class InterviewFeedbackController : Controller
    {
        private readonly IInterviewFeedbackServiceAsync interviewFeedbackServiceAsync;

        public InterviewFeedbackController(IInterviewFeedbackServiceAsync _interviewFeedbackServiceAsync)
        {
            interviewFeedbackServiceAsync = _interviewFeedbackServiceAsync;
        }

        public async Task<IActionResult> Index()
        {
            var InterviewFeedbackCollection = await interviewFeedbackServiceAsync.GetAllInterviewFeedbackAsync();
            return View(InterviewFeedbackCollection);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(InterviewFeedbackRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await interviewFeedbackServiceAsync.AddInterviewFeedbackAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await interviewFeedbackServiceAsync.GetInterviewFeedbackByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(InterviewFeedbackRequestModel model)
        {
            try
            {
                await interviewFeedbackServiceAsync.UpdateInterviewFeedbackAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await interviewFeedbackServiceAsync.GetInterviewFeedbackByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(InterviewFeedbackResponseModel model)
        {
            await interviewFeedbackServiceAsync.DeleteInterviewFeedbackAsync(model.Id);
            return RedirectToAction("Index");

        }
    }
}