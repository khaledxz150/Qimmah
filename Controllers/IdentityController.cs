using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Qimmah.Attributes;
using Qimmah.Core.System;
using Qimmah.Data.User;
using Qimmah.Enums.System;
using Qimmah.Helpers;
using Qimmah.Models.Identity;
using Qimmah.Security;

namespace Qimmah.Controllers
{
    public class IdentityController : Controller
    {
        private readonly Core.System.ILookupService _lookupService;
        private readonly UserManager<Users> _userManager;
        private readonly RoleManager<IdentityRole<long>> _roleManager;

        public IdentityController(ILookupService lookupService, UserManager<Users> userManager, RoleManager<IdentityRole<long>> roleManager)
        {
            _lookupService = lookupService;
            this._userManager = userManager;
            this._roleManager = roleManager;
        }
        public async Task<IActionResult> Login()
        {
            return View(new UserLoginViewModel());
        }
        public async Task<IActionResult> Register()
        {
           return View(new UserRegisterViewModel() { CountriesDDL = await _lookupService.GetLookupsAsDDLAsync(LookupCategoryEnum.Countries, GetLanguageIdFromLocalCookie()) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromBody]UserRegisterViewModel SaveModel)
        {
            if (!ModelState.IsValid)
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState
                        .Where(kvp => kvp.Value.Errors.Any())
                        .ToDictionary(
                            kvp => kvp.Key,
                            kvp => string.Join(" ", kvp.Value.Errors.Select(e => e.ErrorMessage))
                        );

                    return Json(new { success = false, errors });
                }
            }
            else
            {
                var user = new Users
                {
                    UserName = SaveModel.Email,
                    Email = SaveModel.Email,
                    LanguageID = GetLanguageIdFromLocalCookie(),
                    PhoneNumber = SaveModel.PhoneNumber,
                };

                var result = await _userManager.CreateAsync(user, SaveModel.Password);

                if (!result.Succeeded)
                {
                    var DictionaryErrors = new Dictionary<string, string>();
                    foreach (var item in result.Errors)
                    {
                        AssignErrorsToDictionary(item.Code, DictionaryErrors);
                    }
                    return Json(new { success = false, errors = DictionaryErrors });

                }

                await _userManager.AddToRoleAsync(user, "User");

                var principal = await AuthenticationManager.CreateUserPrincipalAsync(_userManager, user);
                await HttpContext.SignInAsync(
                     IdentityConstants.ApplicationScheme,
                    principal,
                    new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(60)
                    });

                return Json(new
                {
                    success = true,
                    redirectUrl = Url.Action("Index", "Home")
                });
            }
            return View(SaveModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromBody] UserLoginViewModel SaveModel)
        {
            if (!ModelState.IsValid)
            {
               
               var errors = ModelState
                   .Where(kvp => kvp.Value.Errors.Any())
                   .ToDictionary(
                       kvp => kvp.Key,
                       kvp => string.Join(" ", kvp.Value.Errors.Select(e => e.ErrorMessage))
                   );

               return Json(new { success = false, errors });
                
            }
            else
            {
                var user = await _userManager.FindByEmailAsync(SaveModel.Email);

                if (user == null)
                {
                    ModelState.AddModelError("Email", GetWord(187)); 
                    return Json(new { success = false, errors = ModelState.ToDictionary(k => k.Key, v => v.Value.Errors.FirstOrDefault()?.ErrorMessage) });
                }

                var result = await _userManager.CheckPasswordAsync(user, SaveModel.Password);

                if (!result)
                {
                    ModelState.AddModelError("Email", GetWord(187));
                    return Json(new { success = false, errors = ModelState.ToDictionary(k => k.Key, v => v.Value.Errors.FirstOrDefault()?.ErrorMessage) });
                }

                var principal = await AuthenticationManager.CreateUserPrincipalAsync(_userManager, user);
                await HttpContext.SignInAsync(
                     IdentityConstants.ApplicationScheme,
                    principal,
                    new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(60)
                    });

                return Json(new
                {
                    success = true,
                    redirectUrl = Url.Action("Index", "Home")
                });

            }
           
        }

        public async Task<RedirectToActionResult> Logout()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return RedirectToAction("Index", "Home");
        }

        private void AssignErrorsToDictionary(string Code, Dictionary<string,string> DictionaryErrors)
        {
            switch (Code)
            {
                case "DuplicateUserName":
                case "DuplicateEmail":
                    DictionaryErrors["Email"] = GetWord(173); // "البريد الإلكتروني مستخدم"
                    break;

                case "InvalidEmail":
                case "InvalidUserName":
                    DictionaryErrors["Email"] = GetWord(174); // "بريد إلكتروني غير صالح"
                    break;

                case "PasswordTooShort":
                    DictionaryErrors["Password"] = GetWord(175); // "كلمة المرور قصيرة جدًا"
                    break;

                case "PasswordRequiresNonAlphanumeric":
                    DictionaryErrors["Password"] = GetWord(176); // "يجب أن تحتوي كلمة المرور على رمز"
                    break;

                case "PasswordRequiresDigit":
                    DictionaryErrors["Password"] = GetWord(177); // "يجب أن تحتوي كلمة المرور على رقم"
                    break;

                case "PasswordRequiresLower":
                    DictionaryErrors["Password"] = GetWord(178); // "يجب أن تحتوي كلمة المرور على حرف صغير"
                    break;

                case "PasswordRequiresUpper":
                    DictionaryErrors["Password"] = GetWord(179); // "يجب أن تحتوي كلمة المرور على حرف كبير"
                    break;

                case "PasswordMismatch":
                    DictionaryErrors["PasswordConfirmation"] = GetWord(180); // "كلمتا المرور غير متطابقتين"
                    break;

                case "UserAlreadyInRole":
                    DictionaryErrors["Role"] = GetWord(181); // "المستخدم لديه هذا الدور بالفعل"
                    break;

                default:
                    DictionaryErrors[""] = GetWord(182); // fallback (or use GetWord with a general error)
                    break;
            }
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
