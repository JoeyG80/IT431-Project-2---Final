using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFSecurityShell.Models
{
    public class Applicant
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Must be 9 digits in length.")]
        [Display(Name = "Social Security Number")]
        public string SSN { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Must enter a name.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Must enter a name.")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Must enter a name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression("^[0-9]{10,10}$", ErrorMessage = "Phone number must be 5 digits in length.")]
        [Display(Name = "Home Phone Number")]
        public string HomePhone { get; set; }
        [Required]
        [RegularExpression("^[0-9]{10,10}$", ErrorMessage = "Phone number must be 5 digits in length.")]
        [Display(Name = "Cell Phone Number")]
        public string CellPhone { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Must enter an Address")]
        public string Address { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Must enter a Street")]
        public string Street { get; set; }
        [Required]
        [Display(Name = "State")]
        public States State { get; set; }
        [Required]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Zip code must be 5 digits in length.")]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public Genders Gender { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z]*$")]
        [Display(Name = "Highschool")]
        public string Name { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z]*$")]
        [Display(Name = "City")]
        public string City { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Graduation Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime GradDate { get; set; }
        [Required]
        [Range(0, 4.00)]
        [Display(Name = "GPA (4.0 Scale)")]
        public double GPA { get; set; }
        [Required]
        [Range(0, 800)]
        [Display(Name = "Math Score (Range: 0-800)")]
        public int Math { get; set; }
        [Required]
        [Range(0, 800)]
        [Display(Name = "Verbal Score (Range: 0-800)")]
        public int Verbal { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z]*$")]
        [Display(Name = "Primary area of intrest")]
        public string AOF { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Prospective Enrollement Date")]
        public DateTime PED { get; set; }
        [Required]
        [Display(Name = "Fall/Spring/Summer")]
        public Seasons Season { get; set; }
        [Required]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Year is a 4 digit number")]
        [Display(Name = "Expected Graduation Year")]
        public string Year { get; set; }
        [Display(Name = "Status: Admit/Reject/Wait List")]
        public Statuses Status { get; set; }

    }
}