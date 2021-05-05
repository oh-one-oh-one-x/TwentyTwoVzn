using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TwentyTwoVzn.Models
{
    public class Business
    {
        [Key]
        public int BusID { get; set; }
        [Required]
        [Display(Name = "Business Name")]
        public string BusName { get; set; }
        [Required]
        [Display(Name = "Location")]
        public string BusLocation { get; set; }
        [Required]
        [Display(Name = "Contact")]
        public int BusContact { get; set; }
        [Required]
        [Display(Name = "Owner")]
        public string BusOwner { get; set; }
        [Required]
        [Display(Name = "Information")]
        public string BusInfo { get; set; }

        public string UserId { get; set; }
        //public string BusTradingHours { get; set; }
    }
}