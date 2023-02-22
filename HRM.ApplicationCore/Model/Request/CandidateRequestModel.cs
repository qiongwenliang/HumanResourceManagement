using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Model.Request
{
    public class CandidateRequestModel
    {

        public int Id { get; set; }
        //these are the four properties that we will take as an input
        [Required(ErrorMessage = "First Name is required")]

        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Mobile Number is required")]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Email Id is required")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }
 
    }
}
