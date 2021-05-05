using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TwentyTwoVzn.Models
{
    public class ServiceType
    {
        [Key]
        public int TypeID { get; set; }
        [Display(Name = "Service Type")]
        [Required]
        public string TypeName { get; set; }
    }
}