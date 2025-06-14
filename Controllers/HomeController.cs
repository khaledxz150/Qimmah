using System.Diagnostics;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Qimmah.Data;
using Qimmah.Models;
using Qimmah.Models.Localization;
using Microsoft.AspNetCore.Identity;

namespace Qimmah.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
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

        [HttpPost]
        public async Task<IActionResult> ChangeLanguageID(ChangeLanaugeSaveModel request)
        {
            if (request == null)
                return BadRequest();

            var language = await _context.Languages
                .FirstOrDefaultAsync(x => x.ID == request.LanguageID.ToAnyType<int>());

            if (language == null)
                return NotFound("Language not found");

            // Save language to cookie (existing logic)
            SetLanguageIdInLocalCookie(language.ID, language.Direction, language.Description);

            // ✅ Update claim if user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                var identity = (ClaimsIdentity)User.Identity;

                // Remove old LanguageID claim if it exists
                var oldClaim = identity.FindFirst("LanguageID");
                if (oldClaim != null)
                    identity.RemoveClaim(oldClaim);

                // Add updated claim
                identity.AddClaim(new Claim("LanguageID", language.ID.ToString()));

                // Re-sign in the user with updated claims
                await HttpContext.SignInAsync(
                     IdentityConstants.ApplicationScheme,
                    new ClaimsPrincipal(identity),
                    new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(60)
                    });
            }

            return Ok();
        }


    }
}
