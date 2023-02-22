
using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using Microsoft.AspNetCore.Mvc;


//MVC is taking the input from the user and send it to repository. When you want to display the data, MVC will take the data from services,
//and display it to the user. So there must not be any logic entered into MVC.

namespace HRM.WebMVCApp.Controllers
{
    public class CandidateController : Controller
    {
        private readonly ICandidateServiceAsync candidateServiceAsync;
        //global variable, it can be accessed anywhere in the class, so it must be readonly and private for security reason.

        public CandidateController(ICandidateServiceAsync _candidateServiceAsync)
        {
            candidateServiceAsync = _candidateServiceAsync;
        }
        public async Task<IActionResult> Index()
        {
            var candidateCollection = await candidateServiceAsync.GetAllCandidateAsync();
            return View(candidateCollection);
        }

        public IActionResult Create()
        {
            return View();
            //this create method will be called when you give the url of create
            //eg, port:5503/candidate/create
        }


        [HttpPost]
        //need to designate it with HttpPost request 
        //means if candidate has sumbit something, then this view will be returned
        //because it take CandidateRequestModel parameter, and it take the value from MVC
        public async Task<IActionResult> Create(CandidateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await candidateServiceAsync.AddCandidateAsync(model);
                return RedirectToAction("Index");
                //it will redirect to the action of Index and show add candidates again.
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await candidateServiceAsync.GetCandidateByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CandidateRequestModel model)
        {
            try
            {
                await candidateServiceAsync.UpdateCandidateAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await candidateServiceAsync.GetCandidateByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CandidateResponseModel model)
        {
            await candidateServiceAsync.DeleteCandidateAsync(model.Id);
            return RedirectToAction("Index");
        }

    }
}
