using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TwentyTwoVzn.Models
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }
        [Required]
        [Display(Name = "Comment")]
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        [Required]
        [Display(Name = "Rating")]
        public int Rating { get; set; }
        public int ServiceID { get; set; }
        [ForeignKey("ServiceID")]
        public virtual Service Service { get; set; }
    }
}