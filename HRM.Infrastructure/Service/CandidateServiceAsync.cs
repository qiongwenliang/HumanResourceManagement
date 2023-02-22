using HRM.ApplicationCore.Contract.Repository;
using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Entity;
using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Infrastructure.Service
{
    public class CandidateServiceAsync : ICandidateServiceAsync
    {
        //important!!!
        //these methods are giving us the data from MVC that must go forward to CandidateRepositoryAsync
        //and CandidateRepositoryAsync will get the add method(from insert) from BaseRepository and insert the data
        //if we want to use CandidateRepositoryAsync, we must create an object and inject.
        //how to create it? use constructor

        //in program.cs we have injected ICandidateRepositoryAsync, and whenever we want to use an object of
        //ICandidateRepositoryAsync, it automatically create an object of CandidateRepositoryAsync

        private readonly ICandidateRepositoryAsync candidateRepositoryAsync;

        public CandidateServiceAsync(ICandidateRepositoryAsync _candidateRepositoryAsync)
        {
            candidateRepositoryAsync = _candidateRepositoryAsync;
        }

        
        public Task<int> AddCandidateAsync(CandidateRequestModel model)
        {
            Candidate candidate = new Candidate()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailId = model.EmailId,
                Mobile = model.Mobile
            };
            return candidateRepositoryAsync.InsertAsync(candidate);
        }


        public Task<int> DeleteCandidateAsync(int id)
        {
            return candidateRepositoryAsync.DeleteAsync(id);
        }


        public async Task<IEnumerable<CandidateResponseModel>> GetAllCandidateAsync()
        {
            var result = await candidateRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new CandidateResponseModel()
                { Id = x.Id, EmailId = x.EmailId, FirstName = x.FirstName, LastName = x.LastName, Mobile = x.Mobile });
            }
            return null;

        }


        public async Task<CandidateResponseModel> GetCandidateByIdAsync(int id)
        {
            var result = await candidateRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new CandidateResponseModel()
                {
                    Id = result.Id,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Mobile = result.Mobile,
                    EmailId = result.EmailId

                };
            }
            return null;
        }


        public Task<int> UpdateCandidateAsync(CandidateRequestModel model)
        {
            Candidate candidate = new Candidate()
            {
                Id = model.Id,
                EmailId = model.EmailId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Mobile = model.Mobile
            };
            return candidateRepositoryAsync.UpdateAsync(candidate);
        }
    }
}
