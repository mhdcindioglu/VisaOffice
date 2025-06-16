using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using VisaOffice.Models;

namespace VisaOffice.Controllers;

public class HomeController : BaseController
{
    public IActionResult Index()
    {
        var visaTypes = GetVisaTypes().Take(3).ToList();
        return View(visaTypes);
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View(new ContactMessage());
    }

    [HttpPost]
    public IActionResult Contact(ContactMessage message)
    {
        if (ModelState.IsValid)
        {
            // In a real application, you would save this to a database
            // For now, we'll just show a success message
            TempData["SuccessMessage"] = "Mesajınız için teşekkür ederiz. En kısa sürede size döneceğiz! / Thank you for your message. We will get back to you soon!";
            return RedirectToAction("Contact");
        }
        return View(message);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private List<VisaType> GetVisaTypes()
    {
        return new List<VisaType>
        {
            new VisaType
            {
                Name = Resources.TouristVisa,
                Description = Resources.TouristVisaDesc,
                ProcessingTime = "5-10 iş günü / 5-10 business days",
                Fee = 60, // Updated for Turkey visa fees (USD)
                IconClass = "fas fa-camera",
                Requirements = new List<string> 
                { 
                    "Geçerli pasaport (en az 6 ay geçerlilik) / Valid passport (minimum 6 months validity)", 
                    "2 adet pasaport fotoğrafı / 2 passport photos", 
                    "Seyahat planı / Travel itinerary", 
                    "Otel rezervasyonu / Hotel reservation",
                    "Banka hesap özeti (son 3 ay) / Bank statements (last 3 months)",
                    "Seyahat sigortası / Travel insurance"
                }
            },
            new VisaType
            {
                Name = Resources.BusinessVisa,
                Description = Resources.BusinessVisaDesc,
                ProcessingTime = "3-7 iş günü / 3-7 business days",
                Fee = 80,
                IconClass = "fas fa-briefcase",
                Requirements = new List<string> 
                { 
                    "Geçerli pasaport (en az 6 ay geçerlilik) / Valid passport (minimum 6 months validity)", 
                    "Türk firmasından davet mektubu / Business invitation letter from Turkish company", 
                    "Şirket kayıt belgeleri / Company registration documents", 
                    "Mali durum belgeleri / Financial statements",
                    "Ziyaret amacı belgesi / Purpose of visit documentation",
                    "İş seyahat sigortası / Business travel insurance"
                }
            },
            new VisaType
            {
                Name = Resources.StudentVisa,
                Description = Resources.StudentVisaDesc,
                ProcessingTime = "10-15 iş günü / 10-15 business days",
                Fee = 110,
                IconClass = "fas fa-graduation-cap",
                Requirements = new List<string> 
                { 
                    "Geçerli pasaport (en az 6 ay geçerlilik) / Valid passport (minimum 6 months validity)", 
                    "Türk üniversitesinden kabul mektubu / Acceptance letter from Turkish university", 
                    "Mali destek belgesi / Proof of financial support", 
                    "Akademik transkript ve diplomalar / Academic transcripts and certificates",
                    "Sağlık raporu / Medical examination report",
                    "Öğrenci sigortası / Student insurance coverage"
                }
            },
            new VisaType
            {
                Name = Resources.WorkVisa,
                Description = Resources.WorkVisaDesc,
                ProcessingTime = "15-20 iş günü / 15-20 business days",
                Fee = 190,
                IconClass = "fas fa-tools",
                Requirements = new List<string> 
                { 
                    "Geçerli pasaport (en az 6 ay geçerlilik) / Valid passport (minimum 6 months validity)", 
                    "Türk işverenden iş teklifi mektubu / Job offer letter from Turkish employer", 
                    "Çalışma izni / Work permit", 
                    "Eğitim ve mesleki sertifikalar / Educational and professional certificates",
                    "Sağlık raporu / Medical examination report",
                    "İş sözleşmesi / Employment contract"
                }
            },
            new VisaType
            {
                Name = Resources.TransitVisa,
                Description = Resources.TransitVisaDesc,
                ProcessingTime = "2-5 iş günü / 2-5 business days",
                Fee = 20,
                IconClass = "fas fa-plane",
                Requirements = new List<string> 
                { 
                    "Geçerli pasaport (en az 6 ay geçerlilik) / Valid passport (minimum 6 months validity)", 
                    "Onward bilet / Confirmed onward ticket", 
                    "Transit planı / Transit itinerary",
                    "Varış ülkesi vizesi (gerekirse) / Visa for final destination (if required)"
                }
            },
            new VisaType
            {
                Name = Resources.FamilyVisa,
                Description = Resources.FamilyVisaDesc,
                ProcessingTime = "7-12 iş günü / 7-12 business days",
                Fee = 80,
                IconClass = "fas fa-users",
                Requirements = new List<string> 
                { 
                    "Geçerli pasaport (en az 6 ay geçerlilik) / Valid passport (minimum 6 months validity)", 
                    "Aile üyesinden davet mektubu / Invitation letter from family member", 
                    "Akrabalık belgesi / Proof of relationship", 
                    "Sponsor belgeleri ve mali durum / Sponsor's documents and financial proof",
                    "Aile fotoğrafları / Family photographs",
                    "Konaklama düzenlemeleri / Accommodation arrangements"
                }
            }
        };
    }
}
