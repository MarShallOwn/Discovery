using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discovery.Core.Models
{
    public class Child : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
        public string Degree { get; set; }
        public string Disability_Type { get; set; }
        public string ClassRoom { get; set; }
        public Teacher TeacherId { get; set; }

        public Child()
        {
            this.Password = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 8);
        }

    }

}
