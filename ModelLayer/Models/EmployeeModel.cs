using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Models
{
    public class EmployeeModel
    {
        [Required(ErrorMessage ="Enter Employee Name")]
        public string EmployeeName { get; set; }



        [Required(ErrorMessage = "Add Profile path")]
        public string ImagePath { get; set; }



        [Required(ErrorMessage ="Gender is Required")]
        public string Gender { get; set; }



        [Required(ErrorMessage ="Enter Department")]
        public string Department { get; set; }



        [Required(ErrorMessage ="Enter Employee Salary")]
        public Decimal Salary { get; set; }



        [Required(ErrorMessage ="Select Start Date")]
        public DateTime StartDate { get; set; }



        [Required(ErrorMessage ="Enter a Note For Employee")]
        public string Notes { get; set; }
    }
}
