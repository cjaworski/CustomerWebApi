using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApp.Models
{
    public class Customer
    {
        public long Id { get; set; }
        [StringLength(60)]
        [Required]
        public string Name { get; set; }
        [StringLength(60)]
        [Required]
        public string Surname { get; set; }
        [RegularExpression(@"^\+?\d+$", ErrorMessage = "The PhoneNumber field is not a valid phone number")]
        [StringLength(30)]
        public string PhoneNumber { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
    }
}
