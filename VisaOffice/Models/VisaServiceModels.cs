namespace VisaOffice.Models
{
    public class VisaType
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ProcessingTime { get; set; } = string.Empty;
        public decimal Fee { get; set; }
        public List<string> Requirements { get; set; } = new List<string>();
        public string IconClass { get; set; } = string.Empty;
    }
    
    public class Document
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsRequired { get; set; }
        public string Category { get; set; } = string.Empty;
    }
    
    public class FAQ
    {
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }
    
    public class ServiceOffice
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string WorkingHours { get; set; } = string.Empty;
        public List<string> Services { get; set; } = new List<string>();
    }
}
