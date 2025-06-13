using System.ComponentModel.DataAnnotations;
namespace Qimmah.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class JRequiredAttribute : RequiredAttribute
{
    public readonly bool _isRequired;
    public readonly int _localizationKey;
    public readonly string[] _replacee;
    public readonly double? _Min;
    public readonly double? _Max;
    public readonly double? _minLength;
    public readonly double? _maxLength;

    /// <summary>
    /// Creates a JRequiredAttribute instance for property validation.
    /// </summary>
    /// <param name="isRequired">Indicates if the property is required.</param>
    /// <param name="localizationKey">The localization key for error message lookup.</param>
    public JRequiredAttribute(bool isRequired, int localizationKey, params string[] replacee )
    {
        _isRequired = isRequired;
        _localizationKey = localizationKey;
        _replacee = replacee;
    }

    public JRequiredAttribute(bool isRequired, int localizationKey, double min, double max, double minLength, double maxLength, params string[] replacee)
    {
        _isRequired = isRequired;
        _localizationKey = localizationKey;
        _replacee = replacee;
        _Min = min;
        _Max = max;
        _minLength = minLength;
        _maxLength = maxLength;
    }





    public JRequiredAttribute(bool isRequired)
    {
        _isRequired = isRequired;
    }

    public JRequiredAttribute(bool isRequired, int localizationKey)
    {
        _isRequired = isRequired;
        _localizationKey = localizationKey;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var validationWord = GetWord(_localizationKey);

        if (_isRequired)
        {
            if (value is not null)
            {
                // Check numeric range if applicable
                if (_Min.HasValue && _Max.HasValue && _Max != 0 &&
                    double.TryParse(value.ToString(), out double doubleValue))
                {
                    if (doubleValue < _Min || doubleValue > _Max)
                    {
                        return new ValidationResult(GetWord(_localizationKey));
                    }
                }

                // Check string length range if applicable
                if (_minLength.HasValue && _minLength > 0 || _maxLength.HasValue && _maxLength > 0)
                {
                    var strValue = value.ToString();
                    if (_minLength.HasValue && _minLength > 0 && strValue.Length < _minLength)
                    {
                        if (_replacee.IsNotNullOrEmpty())
                        {
                            for (int i = 0; i < _replacee.Length; i++)
                            {
                                validationWord = validationWord.Replace($"{{{i}}}", _replacee[i]);
                            }
                        }
                        return new ValidationResult(GetWord(_localizationKey));
                    }
                    if (_maxLength.HasValue && _maxLength > 0 && strValue.Length > _maxLength)
                    {
                        for (int i = 0; i < _replacee.Length; i++)
                        {
                            validationWord = validationWord.Replace($"{{{i}}}", _replacee[i]);
                        }
                        return new ValidationResult(GetWord(_localizationKey));
                    }
                }

                return ValidationResult.Success;
            }
            //var wrapper = validationContext.GetRequiredService<GrpcServicesWrapper>();
            //var response = wrapper.DictionaryLocalizationClient.GetDictionaryLocalizationAsync(new DictionaryRequest()
            //{
            //    LstIDs = { _localizationKey },
            //    LstIDsLength = 1
            //}).GetAwaiter().GetResult();
            if (_replacee.IsNotNullOrEmpty())
            {
                for (int i = 0; i < _replacee.Length; i++)
                {
                    validationWord = validationWord.Replace($"{{{i}}}", _replacee[i]);
                }
            }
            return new ValidationResult(validationWord);
        }
        return ValidationResult.Success;



    }

}