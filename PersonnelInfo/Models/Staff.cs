using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PersonnelInfo.Models
{
    public class Staff
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        [Required]
        public string LastName { set; get; }
        [Required]
        public string FirstName { set; get; }
        [Required]
        public string Address { set; get; }
        [Required]
        public string Designation { set; get; }
        [Required]
        public string StaffNo { set; get; }
    }
}
