using Microsoft.AspNetCore.Mvc;
using VisaOffice.Models;

namespace VisaOffice.Controllers
{
    public class VisaController : BaseController
    {
        public IActionResult Types()
        {
            var visaTypes = GetVisaTypes();
            return View(visaTypes);
        }

        public IActionResult Apply()
        {
            var model = new VisaApplication();
            ViewBag.VisaTypes = GetVisaTypesList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Apply(VisaApplication application)
        {
            if (ModelState.IsValid)
            {
                // In a real application, you would save this to a database
                TempData["SuccessMessage"] = $"Your visa application has been submitted successfully! Application ID: {Guid.NewGuid().ToString("N")[..8].ToUpper()}";
                return RedirectToAction("ApplicationSuccess");
            }
            
            ViewBag.VisaTypes = GetVisaTypesList();
            return View(application);
        }

        public IActionResult ApplicationSuccess()
        {
            return View();
        }

        public IActionResult TrackApplication()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TrackApplication(string applicationId)
        {
            if (string.IsNullOrEmpty(applicationId))
            {
                ModelState.AddModelError("", "Please enter a valid application ID");
                return View();
            }

            // Mock tracking result
            var trackingResult = new
            {
                ApplicationId = applicationId,
                Status = "Under Review",
                SubmissionDate = DateTime.Now.AddDays(-3),
                EstimatedCompletion = DateTime.Now.AddDays(7)
            };

            return View("TrackingResult", trackingResult);
        }

        public IActionResult Requirements()
        {
            var documents = GetRequiredDocuments();
            return View(documents);
        }

        public IActionResult Fees()
        {
            var visaTypes = GetVisaTypes();
            return View(visaTypes);
        }

        private List<VisaType> GetVisaTypes()
        {
            return new List<VisaType>
            {
                new VisaType
                {
                    Name = "Tourist Visa",
                    Description = "Perfect for leisure travel, sightseeing, and vacation purposes. Allows multiple entries for tourism activities.",
                    ProcessingTime = "5-10 business days",
                    Fee = 50,
                    IconClass = "fas fa-camera",
                    Requirements = new List<string> 
                    { 
                        "Valid passport (minimum 6 months validity)", 
                        "2 recent passport-sized photographs", 
                        "Detailed travel itinerary", 
                        "Hotel reservations or accommodation proof",
                        "Bank statements (last 3 months)",
                        "Travel insurance"
                    }
                },
                new VisaType
                {
                    Name = "Business Visa",
                    Description = "For business meetings, conferences, trade shows, and commercial activities.",
                    ProcessingTime = "3-7 business days",
                    Fee = 80,
                    IconClass = "fas fa-briefcase",
                    Requirements = new List<string> 
                    { 
                        "Valid passport (minimum 6 months validity)", 
                        "Business invitation letter from host company", 
                        "Company registration documents", 
                        "Financial statements of the company",
                        "Purpose of visit documentation",
                        "Business travel insurance"
                    }
                },
                new VisaType
                {
                    Name = "Student Visa",
                    Description = "For students enrolled in educational institutions for academic purposes.",
                    ProcessingTime = "10-15 business days",
                    Fee = 120,
                    IconClass = "fas fa-graduation-cap",
                    Requirements = new List<string> 
                    { 
                        "Valid passport (minimum 6 months validity)", 
                        "Official acceptance letter from educational institution", 
                        "Proof of financial support", 
                        "Academic transcripts and certificates",
                        "Medical examination report",
                        "Student insurance coverage"
                    }
                },
                new VisaType
                {
                    Name = "Work Visa",
                    Description = "For individuals seeking employment or already employed in the destination country.",
                    ProcessingTime = "15-20 business days",
                    Fee = 150,
                    IconClass = "fas fa-tools",
                    Requirements = new List<string> 
                    { 
                        "Valid passport (minimum 6 months validity)", 
                        "Job offer letter from employer", 
                        "Work permit or labor certification", 
                        "Educational and professional certificates",
                        "Medical examination report",
                        "Employment contract"
                    }
                },
                new VisaType
                {
                    Name = "Transit Visa",
                    Description = "For travelers passing through the country to reach their final destination.",
                    ProcessingTime = "2-5 business days",
                    Fee = 30,
                    IconClass = "fas fa-plane",
                    Requirements = new List<string> 
                    { 
                        "Valid passport (minimum 6 months validity)", 
                        "Confirmed onward ticket", 
                        "Transit itinerary",
                        "Visa for final destination (if required)"
                    }
                },
                new VisaType
                {
                    Name = "Family Visa",
                    Description = "For visiting family members or relatives residing in the destination country.",
                    ProcessingTime = "7-12 business days",
                    Fee = 75,
                    IconClass = "fas fa-users",
                    Requirements = new List<string> 
                    { 
                        "Valid passport (minimum 6 months validity)", 
                        "Invitation letter from family member", 
                        "Proof of relationship", 
                        "Sponsor's documents and financial proof",
                        "Family photographs",
                        "Accommodation arrangements"
                    }
                }
            };
        }

        private List<string> GetVisaTypesList()
        {
            return GetVisaTypes().Select(v => v.Name).ToList();
        }

        private List<Document> GetRequiredDocuments()
        {
            return new List<Document>
            {
                new Document
                {
                    Name = "Valid Passport",
                    Description = "Original passport with at least 6 months validity and blank pages",
                    IsRequired = true,
                    Category = "Identity"
                },
                new Document
                {
                    Name = "Passport Photos",
                    Description = "2 recent passport-sized photographs (35mm x 45mm)",
                    IsRequired = true,
                    Category = "Identity"
                },
                new Document
                {
                    Name = "Visa Application Form",
                    Description = "Completed and signed visa application form",
                    IsRequired = true,
                    Category = "Application"
                },
                new Document
                {
                    Name = "Bank Statements",
                    Description = "Last 3 months bank statements showing financial stability",
                    IsRequired = true,
                    Category = "Financial"
                },
                new Document
                {
                    Name = "Travel Insurance",
                    Description = "Valid travel insurance covering the entire stay",
                    IsRequired = true,
                    Category = "Insurance"
                },
                new Document
                {
                    Name = "Flight Itinerary",
                    Description = "Round-trip flight reservation (not required to be paid)",
                    IsRequired = true,
                    Category = "Travel"
                },
                new Document
                {
                    Name = "Hotel Reservation",
                    Description = "Confirmed hotel bookings for the entire stay",
                    IsRequired = true,
                    Category = "Accommodation"
                },
                new Document
                {
                    Name = "Employment Letter",
                    Description = "Letter from employer stating position and salary",
                    IsRequired = false,
                    Category = "Employment"
                },
                new Document
                {
                    Name = "Invitation Letter",
                    Description = "Official invitation from host person or organization",
                    IsRequired = false,
                    Category = "Invitation"
                }
            };
        }
    }
}
