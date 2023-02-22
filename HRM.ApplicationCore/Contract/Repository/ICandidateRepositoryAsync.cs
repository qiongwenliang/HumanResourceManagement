using HRM.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Contract.Repository
{
    public interface ICandidateRepositoryAsync: IRepositoryAsync<Candidate> 
    {
        //not only inherit from IRepository, you can also define some candidate specific actions here
    }
}
