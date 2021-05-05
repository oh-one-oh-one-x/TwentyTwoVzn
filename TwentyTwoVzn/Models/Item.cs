using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TwentyTwoVzn.Models
{
    public class Item
    {
        [Required]
        [Display(Name = "Name")]
        public string ItemName { get; set; }
        [Key]
        public int ItemID { get; set; }
        [Display(Name = "Image")]
        
        public byte[] ItemImage { get; set; }
        [Display(Name = "Price")]
        [Required]
        public double ItemPrice { get; set; }
        [Display(Name ="Details")]
        [Required]
        public string ItemDetails { get; set; }
        public int ServiceID { get; set; }
        public virtual Service Service { get; set; }

    }
}