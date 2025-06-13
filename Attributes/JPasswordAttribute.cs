using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Qimmah.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class JPasswordAttribute : ValidationAttribute
{
    public readonly int _localizationKey;
    public readonly string[] _replacee;
    public readonly int _minLength;
    public readonly int _maxLength;
    public readonly bool _requireUppercase;
    public readonly bool _requireLowercase;
    public readonly bool _requireDigits;
    public readonly bool _requireSpecialChars;
    public readonly int _minUppercase;
    public readonly int _minLowercase;
    public readonly int _minDigits;
    public readonly int _minSpecialChars;

    /// <summary>
    /// Creates a JPasswordAttribute for comprehensive password validation
    /// </summary>
    /// <param name="localizationKey">Localization key for error messages</param>
    /// <param name="minLength">Minimum password length</param>
    /// <param name="maxLength">Maximum password length</param>
    /// <param name="requireUppercase">Require uppercase letters</param>
    /// <param name="requireLowercase">Require lowercase letters</param>
    /// <param name="requireDigits">Require digits</param>
    /// <param name="requireSpecialChars">Require special characters</param>
    /// <param name="minUppercase">Minimum number of uppercase letters</param>
    /// <param name="minLowercase">Minimum number of lowercase letters</param>
    /// <param name="minDigits">Minimum number of digits</param>
    /// <param name="minSpecialChars">Minimum number of special characters</param>
    /// <param name="replacee">Replacement parameters for localized messages</param>
    public JPasswordAttribute(
        int localizationKey = 150,
        int minLength = 8,
        int maxLength = 128,
        bool requireUppercase = true,
        bool requireLowercase = true,
        bool requireDigits = true,
        bool requireSpecialChars = true,
        int minUppercase = 1,
        int minLowercase = 1,
        int minDigits = 1,
        int minSpecialChars = 1,
        params string[] replacee)
    {
        _localizationKey = localizationKey;
        _minLength = minLength;
        _maxLength = maxLength;
        _requireUppercase = requireUppercase;
        _requireLowercase = requireLowercase;
        _requireDigits = requireDigits;
        _requireSpecialChars = requireSpecialChars;
        _minUppercase = minUppercase;
        _minLowercase = minLowercase;
        _minDigits = minDigits;
        _minSpecialChars = minSpecialChars;
        _replacee = replacee ?? new string[0];
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
            return ValidationResult.Success; // Let Required handle null values

        string password = value.ToString();
        var errors = new List<string>();

        // Length validation
        if (password.Length < _minLength)
            errors.Add($"Password must be at least {_minLength} characters long");
        if (password.Length > _maxLength)
            errors.Add($"Password must not exceed {_maxLength} characters");

        // Character type validation
        if (_requireUppercase && Regex.Matches(password, @"[A-Z]").Count < _minUppercase)
            errors.Add($"Password must contain at least {_minUppercase} uppercase letter(s)");

        if (_requireLowercase && Regex.Matches(password, @"[a-z]").Count < _minLowercase)
            errors.Add($"Password must contain at least {_minLowercase} lowercase letter(s)");

        if (_requireDigits && Regex.Matches(password, @"[0-9]").Count < _minDigits)
            errors.Add($"Password must contain at least {_minDigits} digit(s)");

        if (_requireSpecialChars && Regex.Matches(password, @"[^a-zA-Z0-9]").Count < _minSpecialChars)
            errors.Add($"Password must contain at least {_minSpecialChars} special character(s)");

        if (errors.Any())
        {
            string errorMessage = null;
            // Let the HTML helper handle localization lookup through your existing system
            return new ValidationResult($"LOCALIZATION_KEY:{_localizationKey}");
        }

        return ValidationResult.Success;
    }

    public List<string> GetPasswordRequirements(Dictionary<int, string>? localizationDictionary)
    {
        var requirements = new List<string>();

        if (localizationDictionary == null)
            return requirements;

        // ID 158: Between {0} and {1} characters
        if (localizationDictionary.TryGetValue(158, out var lengthTemplate))
        {
            requirements.Add(lengthTemplate.Replace("{0}", _minLength.ToString()).Replace("{1}", _maxLength.ToString()));
        }

        // ID 159: At least {0} uppercase letter(s)
        if (_requireUppercase && localizationDictionary.TryGetValue(159, out var upperTemplate))
        {
            requirements.Add(upperTemplate.Replace("{0}", _minUppercase.ToString()));
        }

        // ID 160: At least {0} lowercase letter(s)
        if (_requireLowercase && localizationDictionary.TryGetValue(160, out var lowerTemplate))
        {
            requirements.Add(lowerTemplate.Replace("{0}", _minLowercase.ToString()));
        }

        // ID 161: At least {0} digit(s)
        if (_requireDigits && localizationDictionary.TryGetValue(161, out var digitTemplate))
        {
            requirements.Add(digitTemplate.Replace("{0}", _minDigits.ToString()));
        }

        // ID 162: At least {0} special character(s)
        if (_requireSpecialChars && localizationDictionary.TryGetValue(162, out var specialTemplate))
        {
            requirements.Add(specialTemplate.Replace("{0}", _minSpecialChars.ToString()));
        }

        return requirements;
    }

    public Dictionary<string, object> GetValidationRules()
    {
        return new Dictionary<string, object>
        {
            ["minLength"] = _minLength,
            ["maxLength"] = _maxLength,
            ["requireUppercase"] = _requireUppercase,
            ["requireLowercase"] = _requireLowercase,
            ["requireDigits"] = _requireDigits,
            ["requireSpecialChars"] = _requireSpecialChars,
            ["minUppercase"] = _minUppercase,
            ["minLowercase"] = _minLowercase,
            ["minDigits"] = _minDigits,
            ["minSpecialChars"] = _minSpecialChars
        };
    }

    // Helper method - integrates with your existing localization system
    private string GetWord(int key)
    {
        // This will be handled by your existing localization system
        // The actual implementation should match your current GetWord method
        return null; // Let the calling code handle localization lookup
    }
}