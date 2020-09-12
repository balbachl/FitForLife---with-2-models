using System;
using System.ComponentModel.DataAnnotations;

namespace FitForLife.Models
{
    public class Members
    {
        public int ID { get; set; }
        [Required]
        [StringLength(30,ErrorMessage ="Please enter your full name using 30 characters or less.")]
        public string name { get; set; }
        public string gender { get; set; } = "prefer not to disclose";
        [StringLength(50, ErrorMessage = "Please enter your address using 50 characters or less.")]
        public  string address { get; set; }
        [StringLength(30, ErrorMessage = "Please enter the city using 30 characters or less.")]
        public string city { get; set; }
        [StringLength(2, ErrorMessage = "Please enter the state using 2 characters.")]
        public string state { get; set; }
        [StringLength(10, ErrorMessage = "Zipcode has a maximum length of 10 numbers.")]
        public string zip { get; set; }
        public string email { get; set; }
        public string cell { get; set; }
    }
}