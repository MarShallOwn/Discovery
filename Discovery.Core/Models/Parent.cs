using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discovery.Core.Models
{
    public class Parent : BaseEntity
    {
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public Child Child_Id { get; set; }
        public string Child_Weekly_Report { get; set; }
        public string UserId { get; set; }
    }
}
