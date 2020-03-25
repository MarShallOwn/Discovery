using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discovery.Core.Models
{
    public class Teacher : BaseEntity
    {
        [Required]
        [StringLength(15)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(15)]
        public string LastName { get; set; }
        [Required]
        [RegularExpression("^01[0,1,2,5]{1}[0-9]{8}")]
        [StringLength(11)]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string ClassRoom { get; set; }
      


        public ICollection<Child> Children { get; set; }

    }
}
