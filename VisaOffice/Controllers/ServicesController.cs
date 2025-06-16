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
        }

        public IActionResult LegalConsultation()
        {
            return View();
        }

        private List<dynamic> GetServices()
        {
            return new List<dynamic>
            {
                new { 
                    Name = "Türkiye Vize Başvuru İşlemleri / Turkey Visa Application Processing", 
                    Description = "Tüm vize türleri için kapsamlı vize başvuru işlemleri / Complete visa application processing for all visa types",
                    Icon = "fas fa-passport",
                    Price = "60₺'den başlayan fiyatlarla / From ₺60"
                },
                new { 
                    Name = "Belge Çevirisi / Document Translation", 
                    Description = "Yeminli tercümanlar tarafından resmi belge çevirisi / Official translation of documents by sworn translators",
                    Icon = "fas fa-language",
                    Price = "Sayfa başı 25₺'den / From ₺25/page"
                },
                new { 
                    Name = "Hukuki Danışmanlık / Legal Consultation", 
                    Description = "Göçmenlik ve vize konularında uzman hukuki danışmanlık / Expert legal advice on immigration and visa matters",
                    Icon = "fas fa-gavel",
                    Price = "Saat başı 150₺'den / From ₺150/hour"
                },
                new { 
                    Name = "Randevu Planlaması / Appointment Scheduling", 
                    Description = "Konsolosluk görüşmeleri ve danışmanlık için randevu alma / Book appointments for consulate interviews and consultations",
                    Icon = "fas fa-calendar-alt",
                    Price = "Ücretsiz / Free"
                },
                new { 
                    Name = "Ekspres İşlem / Express Processing", 
                    Description = "Acil başvurular için hızlandırılmış vize işlemleri / Fast-track visa processing for urgent applications",
                    Icon = "fas fa-bolt",
                    Price = "Ek 100₺ / Additional ₺100"
                },
                new { 
                    Name = "Belge İncelemesi / Document Review", 
                    Description = "Başvuru belgelerinizin kapsamlı incelemesi / Comprehensive review of your application documents",
                    Icon = "fas fa-search",
                    Price = "40₺'den başlayan / From ₺40"
                }
            };
        }

        private List<FAQ> GetFAQs()
        {
            return new List<FAQ>
            {
                new FAQ
                {
                    Question = "Türkiye vizesi işlem süresi ne kadar? / How long does Turkey visa processing take?",
                    Answer = "İşlem süreleri vize türüne göre değişir: Turist vizesi 5-10 iş günü, İş vizesi 3-7 iş günü, Öğrenci vizesi 10-15 iş günü, Çalışma vizesi 15-20 iş günü sürer. / Processing times vary by visa type: Tourist visas take 5-10 business days, Business visas take 3-7 business days, Student visas take 10-15 business days, and Work visas take 15-20 business days.",
                    Category = "İşlem / Processing"
                },
                new FAQ
                {
                    Question = "Turist vizesi için hangi belgeler gerekli? / What documents do I need for a tourist visa?",
                    Answer = "Geçerli pasaport (6+ ay geçerlilik), 2 pasaport fotoğrafı, seyahat planı, otel rezervasyonu, banka hesap özeti (son 3 ay) ve seyahat sigortası gereklidir. / You need a valid passport (6+ months validity), 2 passport photos, travel itinerary, hotel bookings, bank statements (last 3 months), and travel insurance.",
                    Category = "Gereksinimler / Requirements"
                },
                new FAQ
                {
                    Question = "Vize başvurumu takip edebilir miyim? / Can I track my visa application?",
                    Answer = "Evet, başvuru yaptığınızda verilen başvuru numarası ile online takip sistemimizi kullanabilirsiniz. / Yes, you can track your application using the application ID provided when you submitted your application. Use our online tracking system.",
                    Category = "Takip / Tracking"
                },
                new FAQ
                {
                    Question = "Vize başvurum reddedilirse ne olur? / What if my visa application is rejected?",
                    Answer = "Reddedilme durumunda detaylı açıklama alırsınız. Red mektubunda belirtilen sorunları giderdikten sonra yeniden başvurabilirsiniz. Yeniden başvuru için ücret ödemeniz gerekebilir. / If rejected, you'll receive a detailed explanation. You can reapply after addressing the issues mentioned in the rejection letter. Fees may apply for reapplication.",
                    Category = "Red / Rejection"
                },
                new FAQ
                {
                    Question = "Vize başvurusu için randevu gerekli mi? / Do I need an appointment for visa submission?",
                    Answer = "Randevusuz da kabul edilmekle birlikte, bekleme sürelerini önlemek ve kişiselleştirilmiş hizmet almak için randevu almanızı önemle tavsiye ederiz. / While walk-ins are accepted, we highly recommend booking an appointment to avoid waiting times and ensure personalized service.",
                    Category = "Randevular / Appointments"
                },
                new FAQ
                {
                    Question = "Hangi ödeme yöntemlerini kabul ediyorsunuz? / What payment methods do you accept?",
                    Answer = "Nakit, kredi kartı, banka kartı ve banka havalesi kabul ediyoruz. Tüm ücretler işlem başlamadan önce ödenmelidir. / We accept cash, credit cards, debit cards, and bank transfers. All fees must be paid before application processing begins.",
                    Category = "Ödeme / Payment"
                },
                new FAQ
                {
                    Question = "Başka biri benim adıma başvuru yapabilir mi? / Can someone else submit my application?",
                    Answer = "Evet, imzalı yetki mektubu ve kimlik kartı fotokopyanız ile başka birini yetkilendirebilirsiniz. / Yes, you can authorize someone to submit on your behalf with a signed authorization letter and copy of your ID.",
                    Category = "Başvuru / Submission"
                },
                new FAQ
                {
                    Question = "Farklı vize türlerinin geçerlilik süreleri nedir? / What is the validity of different visa types?",
                    Answer = "Turist vizeleri genellikle 30-90 gün, İş vizeleri 30-180 gün, Öğrenci vizeleri kurs süresi boyunca, Çalışma vizeleri ise sözleşmeye göre değişir. / Tourist visas are typically valid for 30-90 days, Business visas for 30-180 days, Student visas for the course duration, and Work visas vary by contract.",
                    Category = "Geçerlilik / Validity"
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
