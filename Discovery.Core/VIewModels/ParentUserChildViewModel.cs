using Discovery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discovery.Core.VIewModels
{
    public class ParentUserChildViewModel
    {
        public NurseryUser user { get; set; }
        public Child child  { get; set; }
        public Parent parent { get; set; }
    }
}
