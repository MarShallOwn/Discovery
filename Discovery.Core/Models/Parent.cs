using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discovery.Core.Models
{
    public class Parent : BaseEntity
    {
        public Child Child_Id { get; set; }
        public string Child_Weekly_Report { get; set; }
        public User UserId { get; set; }
    }
}
