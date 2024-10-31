using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mime;

namespace RazorDropDown.Pages.V1
{
    public class DetailsModel : PageModel
    {
        /// <summary>
        /// Kestrel (or Proxy + Kestrel) receives the raw HTTP request.
        //  ASP.NET Core Host uses a HttpContextFactory creates HttpContext,
        //  along with HttpRequest and HttpResponse initialises a new HttpContext
        //  HttpRequest is populated with the URL, headers, and query string, parsed
        //  into a dictionary in HttpRequest.Query.
        /// </summary>
        /// <returns></returns>
        public ActionResult OnGet()
        {

            var ClientIpAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            var ServerPort = HttpContext.Connection.LocalPort;
            // some other interesting things i can see include:
            var Path = HttpContext.Request.Path;
            var Method = HttpContext.Request.Method;
            var ContentType = HttpContext.Request.ContentType;
            var ContentLength = HttpContext.Request.ContentLength;
            var Referer = HttpContext.Request.Headers["Referer"];
            var IsSecureConnection = HttpContext.Request.IsHttps;

            // Read the query string with the name "Grade"
            string choice = HttpContext.Request.Query["Grade"];
            // Put the choice into the ViewBag and display in its own view

            // ViewData is a Key-value Dictionary 
            // it is an instance property of the PageModel class
            // DetailsModel created when the http request 
            // that lives for the duration of the HttpContext
            ViewData["choice"] = choice;
            return Page();
        }
    }
}
