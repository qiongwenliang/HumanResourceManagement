﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Model.Response
{
    public class EmployeeTypeResponseModel
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public bool IsActive { get; set; }
    }
}
