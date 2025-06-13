using Qimmah.Attributes;
using Qimmah.Models.Common;

namespace Qimmah.Models.Identity;


public class RegisterViewModel
{
    [JRequired(true, localizationKey: 123)]
    [JLabel(117)]
    public string? Email { get; set; }

    [JLabel(118)] // "Password"
    [JRequired(isRequired: true, localizationKey: 123)] // "Password is required"
    [JPassword(
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
        )]
    public string Password { get; set; }

    [JLabel(119)] // "Confirm Password"
    [JRequired(isRequired: false, localizationKey: 123)] // "Password confirmation is required"
    [CompareWithKey(nameof(Password), ErrorMessage = "Passwords do not match")]
    public string PasswordConfirmation { get; set; }

    [JLabel(120)]
    [JRequired(true, localizationKey: 123)]
    public string? PhoneNumber { get; set; }

    [JLabel(172)]
    [JRequired(true, localizationKey: 172)]
    public List<DDLViewModel> CountriesDDL { get; set; }
}



