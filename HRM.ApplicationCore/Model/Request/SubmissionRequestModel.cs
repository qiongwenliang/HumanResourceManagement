﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Model.Request
{
    public class SubmissionRequestModel
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int JobRequirementId { get; set; }
        public DateTime AppliedOn { get; set; }
    }
}
