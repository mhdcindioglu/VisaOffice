using System.ComponentModel.DataAnnotations;

namespace VisaOffice.Models
{
    public class VisaApplication
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;
        
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;
        
        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        
        [Required]
        [Display(Name = "Passport Number")]
        public string PassportNumber { get; set; } = string.Empty;
        
        [Required]
        [Display(Name = "Nationality")]
        public string Nationality { get; set; } = string.Empty;
        
        [Required]
        [Display(Name = "Visa Type")]
        public string VisaType { get; set; } = string.Empty;
        
        [Required]
        [Display(Name = "Purpose of Visit")]
        public string PurposeOfVisit { get; set; } = string.Empty;
        
        [Required]
        [Display(Name = "Intended Date of Arrival")]
        [DataType(DataType.Date)]
        public DateTime IntendedArrivalDate { get; set; }
        
        [Required]
        [Display(Name = "Duration of Stay (days)")]
        public int DurationOfStay { get; set; }
        
        [Display(Name = "Additional Information")]
        public string? AdditionalInformation { get; set; }
        
        public DateTime ApplicationDate { get; set; } = DateTime.Now;
        
        public string Status { get; set; } = "Pending";
    }
}
