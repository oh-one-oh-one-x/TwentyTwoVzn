using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TwentyTwoVzn.Models
{
    public class Reserve
    {
        [Key]
        public int ReserveID { get; set; }
        [Required]
        [Display(Name = "No. Of Attendees")]
        public int NumAttendees { get; set; }
        [Required]
        [Display(Name = "Date of Reservation")]
        public DateTime ReserveDate { get; set; }
        public int EventID { get; set; }
        public virtual Event Event { get; set; }
        public string UserId { get; set; }
    }
}