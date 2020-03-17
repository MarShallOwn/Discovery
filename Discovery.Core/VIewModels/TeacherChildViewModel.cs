using Discovery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discovery.Core.VIewModels
{
    public class TeacherChildViewModel
    {
        public string CFirstName { get; set; }
        public string CLastName { get; set; }
        public string CPassword { get; set; }
        public int CAge { get; set; }
        public int CGrade { get; set; }
        public string CDegree { get; set; }
        public string CDisability_Type { get; set; }
        public string CClassRoom { get; set; }
        public string TFirstName { get; set; }
        public string TLastName { get; set; }
        public string TPhoneNumber { get; set; }
        public string TEmail { get; set; }
    }
}
