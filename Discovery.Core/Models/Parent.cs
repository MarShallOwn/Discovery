using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discovery.Core.Models
{
    public class Parent : BaseEntity
    {

        public string Child_Weekly_Report { get; set; }
        public string ChildId { get; set; }
        public string UserId { get; set; }
        public Child Child { get; set; }
        public NurseryUser User { get; set; }
    }
}
