using Microsoft.AspNetCore.Mvc;
using VisaOffice.Models;

namespace VisaOffice.Controllers
{
    public class ServicesController : BaseController
    {
        public IActionResult Index()
        {
            var services = GetServices();
            return View(services);
        }

        public IActionResult FAQ()
        {
            var faqs = GetFAQs();
            return View(faqs);
        }

        public IActionResult Offices()
        {
            var offices = GetServiceOffices();
            return View(offices);
        }

        public IActionResult Appointments()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BookAppointment(string name, string email, string phone, DateTime appointmentDate, string service)
        {
            if (ModelState.IsValid)
            {
                TempData["SuccessMessage"] = $"Randevunuz {appointmentDate:dddd, dd MMMM yyyy} tarihinde {appointmentDate:HH:mm} saatine alınmıştır. Onay detayları {email} adresine gönderilecektir. / Your appointment has been booked for {appointmentDate:dddd, MMMM dd, yyyy} at {appointmentDate:HH:mm}. Confirmation details will be sent to {email}.";
                return RedirectToAction("Appointments");
            }
            return View("Appointments");
        }

        public IActionResult DocumentTranslation()
        {
            return View();
        }        public IActionResult LegalConsultation()
        {
            return View();
        }

        private List<dynamic> GetServices()
        {
            return new List<dynamic>
            {
                new 
                { 
                    Name = Resources.ServiceTurkeyVisaApplication, 
                    Description = Resources.ServiceTurkeyVisaApplicationDesc,
                    Icon = "fas fa-passport",
                    Price = Resources.PriceFrom60,
                },
                new 
                { 
                    Name = Resources.ServiceDocumentTranslation, 
                    Description = Resources.ServiceDocumentTranslationDesc,
                    Icon = "fas fa-language",
                    Price = Resources.PriceFrom25PerPage,
                },
                new 
                { 
                    Name = Resources.ServiceLegalConsultation, 
                    Description = Resources.ServiceLegalConsultationDesc,
                    Icon = "fas fa-gavel",
                    Price = Resources.PriceFrom150PerHour,
                },
                new 
                { 
                    Name = Resources.ServiceAppointmentScheduling, 
                    Description = Resources.ServiceAppointmentSchedulingDesc,
                    Icon = "fas fa-calendar-alt",
                    Price = Resources.PriceFree,
                },
                new 
                { 
                    Name = Resources.ServiceExpressProcessing, 
                    Description = Resources.ServiceExpressProcessingDesc,
                    Icon = "fas fa-bolt",
                    Price = Resources.PriceAdditional100,
                },
                new 
                { 
                    Name = Resources.ServiceDocumentReview, 
                    Description = Resources.ServiceDocumentReviewDesc,
                    Icon = "fas fa-search",
                    Price = Resources.PriceFrom40,
                },
            };
        }        private List<FAQ> GetFAQs()
        {
            return new List<FAQ>
            {
                new FAQ
                {
                    Question = Resources.FAQProcessingTimeQuestion,
                    Answer = Resources.FAQProcessingTimeAnswer,
                    Category = Resources.CategoryProcessing
                },
                new FAQ
                {
                    Question = Resources.FAQTouristRequirementsQuestion,
                    Answer = Resources.FAQTouristRequirementsAnswer,
                    Category = Resources.CategoryRequirements
                },
                new FAQ
                {
                    Question = Resources.FAQTrackingQuestion,
                    Answer = Resources.FAQTrackingAnswer,
                    Category = Resources.CategoryTracking
                },
                new FAQ
                {
                    Question = Resources.FAQRejectionQuestion,
                    Answer = Resources.FAQRejectionAnswer,
                    Category = Resources.CategoryRejection
                },
                new FAQ
                {
                    Question = Resources.FAQAppointmentQuestion,
                    Answer = Resources.FAQAppointmentAnswer,
                    Category = Resources.CategoryAppointments
                },
                new FAQ
                {
                    Question = Resources.FAQPaymentQuestion,
                    Answer = Resources.FAQPaymentAnswer,
                    Category = Resources.CategoryPayment
                },
                new FAQ
                {
                    Question = Resources.FAQAuthorizationQuestion,
                    Answer = Resources.FAQAuthorizationAnswer,
                    Category = Resources.CategorySubmission
                },
                new FAQ
                {
                    Question = Resources.FAQValidityQuestion,
                    Answer = Resources.FAQValidityAnswer,
                    Category = Resources.CategoryValidity
                }
            };
        }

        private List<ServiceOffice> GetServiceOffices()
        {
            return new List<ServiceOffice>
            {
                new ServiceOffice
                {
                    Name = "Ana Ofis - Taksim / Main Office - Taksim",
                    Address = Resources.MainOfficeAddress,
                    Phone = Resources.MainOfficePhone,
                    Email = Resources.MainOfficeEmail,
                    WorkingHours = Resources.MainOfficeHours,
                    Services = new List<string> { "Tüm Vize Türleri / All Visa Types", "Belge Çevirisi / Document Translation", "Hukuki Danışmanlık / Legal Consultation", "Ekspres İşlem / Express Processing" }
                },
                new ServiceOffice
                {
                    Name = "Ankara Şubesi / Ankara Branch",
                    Address = Resources.AnkaraOfficeAddress,
                    Phone = Resources.AnkaraOfficePhone,
                    Email = Resources.AnkaraOfficeEmail,
                    WorkingHours = Resources.AnkaraOfficeHours,
                    Services = new List<string> { "Tüm Vize Türleri / All Visa Types", "Belge Çevirisi / Document Translation", "Hukuki Danışmanlık / Legal Consultation" }
                },
                new ServiceOffice
                {
                    Name = "İzmir Şubesi / İzmir Branch",
                    Address = Resources.IzmirOfficeAddress,
                    Phone = Resources.IzmirOfficePhone,
                    Email = Resources.IzmirOfficeEmail,
                    WorkingHours = Resources.IzmirOfficeHours,
                    Services = new List<string> { "Tüm Vize Türleri / All Visa Types", "Belge Çevirisi / Document Translation", "Turist ve İş Vizeleri / Tourist and Business Visas" }
                }
            };
        }    }
}
