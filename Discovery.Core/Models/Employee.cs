using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Discovery.Core.Models
{
    public class Employee : BaseEntity
    {
        [Required]
        [StringLength(15)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(15)]
        public string LastName { get; set; }
        [Required]
        [Range(20,60)]
        public int Age { get; set; }
        [Required]
        [RegularExpression("123 test st, test city, test Country")]
        public string Street { get; set; }
        [Required]
        public string Job { get; set; }
        [Required]
        [Range(500,3000)]
        public decimal Salary { get; set; }
    }
}
