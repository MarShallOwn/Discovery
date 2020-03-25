using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Discovery.Core.Models
{
    public class Child : BaseEntity
    {
        [Required]
        [StringLength(15)]
        public string FirstName { get; set; }
        [StringLength(15)]
        [Required]
        
        public string LastName { get; set; }
        [Required]

        public string Password { get; set; }

        [Required]
        [Range(1,7)]
        public int Age { get; set; }

        [Required]
        [Range(1,7)]
        public int Grade { get; set; }


        [Required]
        public string Degree { get; set; }

        [Required]
        public string Disability_Type { get; set; }

        [Required]
        public string ClassRoom { get; set; }

        
        public string TeacherId { get; set; }
        
        
        public Teacher Teacher { get; set; }

        public Child()
        {
            this.Password = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 8);
        }

    }

}
