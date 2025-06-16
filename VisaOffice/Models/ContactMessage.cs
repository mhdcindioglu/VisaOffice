using System.ComponentModel.DataAnnotations;

namespace VisaOffice.Models
{
    public class ContactMessage
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty;
        
        [Phone]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }
        
        [Required]
        [Display(Name = "Subject")]
        public string Subject { get; set; } = string.Empty;
        
        [Required]
        [Display(Name = "Message")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; } = string.Empty;
        
        public DateTime MessageDate { get; set; } = DateTime.Now;
    }
}
