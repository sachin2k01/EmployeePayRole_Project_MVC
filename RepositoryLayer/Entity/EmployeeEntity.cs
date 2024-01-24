using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entity
{
    public class EmployeeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }


        public string EmployeeName { get; set; }

        public string ImagePath { get; set; }

        public string Gender { get; set; }

        public string Department { get; set; }
        public Decimal Salary { get; set; }

        public DateTime StartDate { get; set; }

        public string Notes { get; set; }

    }
}
