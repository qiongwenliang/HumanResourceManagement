using HRM.ApplicationCore.Contract.Repository;
using HRM.ApplicationCore.Entity;
using HRM.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Infrastructure.Repository
{
    public class CandidateRepositoryAsync : BaseRepositoryAsync<Candidate>, ICandidateRepositoryAsync
    {
        //baserepositoryasync has a constructor that take one parameter, so we need the following constructor
        public CandidateRepositoryAsync(HRMDbContext _context) : base(_context)
        {
        }

    }
}
