using Microsoft.AspNetCore.Antiforgery;
using EventCloud.Controllers;

namespace EventCloud.Web.Host.Controllers
{
    public class AntiForgeryController : EventCloudControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
