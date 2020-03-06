using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discovery.Core.Models
{
    public class Teacher : BaseEntity
    {
        public string Name { get; set; }
        public string ClassRoom { get; set; }

        public ICollection<Child> Children { get; set; }

    }
}
