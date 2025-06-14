using Qimmah.Attributes;
using Qimmah.Models.Common;

namespace Qimmah.Models.Identity;


public class UserRegisterViewModel
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
    [CompareWithKey(nameof(Password),  ErrorMessage = "168")]
    public string PasswordConfirmation { get; set; }

    [JLabel(120)]
    [JRequired(true, localizationKey: 123)]
    public string? PhoneNumber { get; set; }


    public List<DDLViewModel> CountriesDDL { get; set; } = new List<DDLViewModel>();

    [JLabel(172)]
    [JRequired(true, localizationKey: 123)]
    public string CountryCode { get; set; }
}

public class UserLoginViewModel
{
    [JRequired(true, localizationKey: 123)]
    [JLabel(117)]
    public string? Email { get; set; }

    [JLabel(118)] // "Password"
    [JRequired(isRequired: true, localizationKey: 123)] // "Password is required"
    public string Password { get; set; }
}



