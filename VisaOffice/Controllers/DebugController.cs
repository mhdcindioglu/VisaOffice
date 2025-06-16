using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace VisaOffice.Controllers
{
    public class DebugController : Controller
    {
        public IActionResult Culture()
        {
            var info = new
            {
                CurrentCulture = CultureInfo.CurrentCulture.Name,
                CurrentUICulture = CultureInfo.CurrentUICulture.Name,
                RequestPath = Request.Path.Value,
                QueryString = Request.QueryString.Value,
                RouteValues = RouteData.Values,
                HomeText = Resources.Home,
                BrandNameText = Resources.BrandName,
                VisaServicesText = Resources.VisaServices,
                Headers = Request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString())
            };
            
            return Json(info);
        }
    }
}
