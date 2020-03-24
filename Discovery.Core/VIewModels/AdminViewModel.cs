using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discovery.Core.VIewModels
{
    public class AdminViewModel
    {
        [Required]
        public string userEmail { get; set; }
        public List<string> roles { get; set; }
        public string role { get; set; }
    }
}
