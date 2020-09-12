using System;
using System.ComponentModel.DataAnnotations;

namespace FitForLife.Models
{
    public class Stats
    {
        public int ID { get; set; }
        public DateTime statDate { get; set; } = DateTime.Now;
        [Required]
        [Range(8, 110, ErrorMessage = "Please enter an age between 8 and 110 years old.")]
        public int age { get; set; }
        [Required(ErrorMessage = "Please enter your weight in pounds, it is required to calculate your BMI")]
        [Range(90, 500, ErrorMessage = "Please enter a weight between 90 and 500 pounds.")]
        public float weight { get; set; }
        [Required(ErrorMessage = "Please enter your height in inches, it is required to calculate your BMI")]
        [Range(36, 96, ErrorMessage = "Please enter a height between 36 inches (3 feet) and 96 inches (8 feet).")]
        public float height { get; set; }
        [Required]
        public int MembersID { get; set; }
        public Members Members { get; set; }
        public float? CalcBMI()
        {
            float? BMICalculation = 0;
            BMICalculation = (weight * 703) / (height * height);
            return BMICalculation;
        }

    }
}
