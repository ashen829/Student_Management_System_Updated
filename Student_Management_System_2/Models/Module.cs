using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System_2.Models
{
     public class Module
    {
        [Key]
        public string ModuleId { get; set; }

        public int Semester { get; set; }

        public string ModuleName { get; set; }

        public int Credits { get; set; }

        public string Department { get; set; }
        public string Description { get; set; }

        public string Grade { get; set; }
        

        
    }
}
