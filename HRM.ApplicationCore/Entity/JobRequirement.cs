using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //[Required] is in this model
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Entity
{
    public class JobRequirement
    {
        public int Id { get; set; }
        [Required] //this is an attribute
        [Column(TypeName = "varchar(100)")]
        //this is validation of input value
        public string Title { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Description { get; set; }
        public int TotalPositions { get; set; }
        public DateTime PostingDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public int JobCategoryId { get; set; }
        //one job category can have jobrequirement(roles), so we need to create navigational property
        public bool IsActive { get; set; }

        //navigational property, this will not be used to create a column, it is only used to create a relation.
        public JobCategory JobCategory { get; set; }
    }
}
