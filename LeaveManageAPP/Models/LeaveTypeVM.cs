using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManageAPP.Models
{
    public class LeaveTypeVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Default Days")]
        [Range(1,23,ErrorMessage = "Please Enter valid Number")]
        public int DefaultDays { get; set; }
        [Display(Name = "Date Created")] 
        public DateTime? DateCreated { get; set; }
    }
}
