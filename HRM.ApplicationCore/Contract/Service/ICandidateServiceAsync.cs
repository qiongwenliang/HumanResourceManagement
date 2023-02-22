using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Contract.Service
{
    public interface ICandidateServiceAsync
    {
        //we are using models here, and there are request and response model.
        //so we need to create a model folder, model is very similar to entities
        //but the purpose of model is working with client, not the database itself.
        Task<int> AddCandidateAsync(CandidateRequestModel model);
        Task<int> UpdateCandidateAsync(CandidateRequestModel model);
        Task<int> DeleteCandidateAsync(int id);
        Task<CandidateResponseModel> GetCandidateByIdAsync(int id);
        Task<IEnumerable<CandidateResponseModel>> GetAllCandidateAsync();

        //now we need to implement ICandidateServiceAsync to infrastructure, in the service folder in Infrastructure
    }
}
