using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TwentyTwoVzn.Models
{
    public class Service
    {
        [Key]
        public int ServiceID { get; set; }
        [Display(Name = "Service Name")]
        [Required]
        public string ServiceName { get; set; }
        [Display(Name = "Service Details")]
        [Required]
        public string ServiceDetails { get; set; }
        
        [Display(Name = "Image")]
        public byte[] ServiceImage { get; set; }
        //public string ServiceRate { get; set; }
        [Display(Name = "Service Location")]
        [Required]
        public string ServiceLocation { get; set; }
        public int TypeID { get; set; }
        public virtual ServiceType ServiceTypes { get; set; }
        public int BusinessID { get; set; }
        public virtual Business Business { get;set; }
        //public int TotalRating
        //{
        //    get { return (Review.Sum(x => x.Rate)); }
        //}
        //public int CountRating
        //{
        //    get { return Review.Count; }
        //}
    }
}