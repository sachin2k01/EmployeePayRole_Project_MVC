using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Models
{
    public class EmployeeModel
    {
        [Required]
        public string EmployeeName { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Department { get; set; }
        [Required]
        public Decimal Salary { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public string Notes { get; set; }
    }
}
