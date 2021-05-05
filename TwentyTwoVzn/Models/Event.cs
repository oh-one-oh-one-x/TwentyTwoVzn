using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TwentyTwoVzn.Models
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }
        [Display(Name = "Event Name")]
        [Required]
        public string EventName { get; set; }
        [Display(Name = "Event Date")]
        [Required]
        public DateTime EventDate { get; set; }
        [Display(Name = "Event Host")]
        [Required]
        public string Host { get; set; }
        [Display(Name = "Entrance Fee")]
        public byte[] Image { get; set; }
        public double EventFee { get; set; }
        [Display(Name = "Event Cap")]
        [Required]
        public int EventCapacity { get; set; }
        [Display(Name = "Status")]
        public string EventStatus { get; set; }
        [Display(Name = "Location")]
        [Required]
        public string Location { get; set; }
        public int BusinessID { get; set; }
        public virtual Business Business { get; set; }
    }
}