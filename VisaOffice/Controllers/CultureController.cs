using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace VisaOffice.Controllers
{
    public class CultureController : Controller
    {
        [HttpPost]
        public IActionResult SetCulture(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(GetLocalizedUrl(culture, returnUrl));
        }        [HttpGet]
        public IActionResult ChangeCulture(string culture, string returnUrl)
        {
            // Set the culture cookie
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(GetLocalizedUrl(culture, returnUrl));
        }

        private string GetLocalizedUrl(string culture, string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl))
                returnUrl = "/";

            // Remove any existing culture prefix from the return URL
            var supportedCultures = new[] { "en-US", "tr-TR" };
            foreach (var supportedCulture in supportedCultures)
            {
                var culturePrefix = "/" + supportedCulture;
                if (returnUrl.StartsWith(culturePrefix, StringComparison.OrdinalIgnoreCase))
                {
                    returnUrl = returnUrl.Substring(culturePrefix.Length);
                    if (string.IsNullOrEmpty(returnUrl))
                        returnUrl = "/";
                    break;
                }
            }

            // Add the new culture prefix
            return $"/{culture}{returnUrl}";
        }
    }
}
