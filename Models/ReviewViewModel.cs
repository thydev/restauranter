using System;
using System.ComponentModel.DataAnnotations;


namespace restauranter.Models
{
    public class ReviewViewModel 
    {
        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage="Name must be only characters.")]
        [Display(Name="Reviewer name")]
        // [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string ReviewerName { get; set; }

        [Required(ErrorMessage="Restaurant Name is required")]
        [Display(Name="Restaurant name")]
        public string RestaurantName { get; set; }

        [Required]
        [MinLength(10, ErrorMessage="Review must be longer thatn 10 characters")]
        // [StringLength(1000)]
        [Display(Name="Review")]
        public string ReviewText { get; set; }

        [Required]
        [Range(1, 5)]
        [Display(Name="Stars")]
        public int Rating { get; set; }

        [Required]
        [Display(Name="Date of visit")]
        [DataType(DataType.Date)]
        [FutureDate(ErrorMessage="Date of visit should be in the future.")]
        // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateVisit { get; set; }

        public int Helpful { get; set; }
        public int Unhelpful { get; set; }
    }
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value != null && (DateTime)value < DateTime.Now;
        }
    }
}