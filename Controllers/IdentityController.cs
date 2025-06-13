using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Qimmah.Attributes;
using Qimmah.Core.System;
using Qimmah.Enums.System;
using Qimmah.Helpers;
using Qimmah.Models.Identity;

namespace Qimmah.Controllers
{
    public class IdentityController : Controller
    {
        private readonly Core.System.ILookupService _lookupService;

        public IdentityController(ILookupService lookupService)
        {
            _lookupService = lookupService;
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }
        public async Task<IActionResult> Register()
        {
            return View(new RegisterViewModel() { CountriesDDL = await _lookupService.GetLookupsAsDDLAsync(LookupCategoryEnum.Countries, GetLanguageIdFromLocalCookie()) });
        }

        // API endpoint for real-time password validation
        [HttpPost]
        public IActionResult ValidatePassword([FromBody] PasswordValidationRequest request)
        {
            var attribute = new JPasswordAttribute(
                localizationKey: 150,
                minLength: 8,
                maxLength: 128,
                requireUppercase: true,
                requireLowercase: true,
                requireDigits: true,
                requireSpecialChars: true,
                minUppercase: 1,
                minLowercase: 1,
                minDigits: 1,
                minSpecialChars: 1
            );

            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(request)
            {
                MemberName = nameof(request.Password)
            };

            var result = attribute.GetValidationResult(request.Password, validationContext);

            return Json(new
            {
                isValid = result == System.ComponentModel.DataAnnotations.ValidationResult.Success,
                message = result?.ErrorMessage,
                requirements = attribute.GetPasswordRequirements(HttpContext.GetLocalization()),
                rules = attribute.GetValidationRules()
            });
        }
    }
}
