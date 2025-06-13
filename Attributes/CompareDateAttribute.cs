using System.ComponentModel.DataAnnotations;

namespace Qimmah.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class CompareDateAttribute : ValidationAttribute
{
    private readonly string _comparisonProperty;
    private readonly bool _shouldBeEarlier;

    public CompareDateAttribute(string comparisonProperty, bool shouldBeEarlier = true)
    {
        _comparisonProperty = comparisonProperty;
        _shouldBeEarlier = shouldBeEarlier;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var instance = validationContext.ObjectInstance;
        var type = instance.GetType();
        var mainProperty = type.GetProperty(validationContext.MemberName);
        var comparisonProperty = type.GetProperty(_comparisonProperty);

        if (comparisonProperty == null)
        {
            return new ValidationResult($"Unknown property: {_comparisonProperty}");
        }
        int localizationKey = GetAttributeValue<JLabelAttribute, int>(comparisonProperty, x => x.Key);
        var comparisonValue = comparisonProperty.GetValue(instance);   
        
        
        int localizationKey2 = GetAttributeValue<JLabelAttribute, int>(mainProperty, x => x.Key);
        var comparisonValue2 = mainProperty.GetValue(instance);

        if (value == null || comparisonValue == null)
        {
            return ValidationResult.Success;
        }

        if (value is DateTime startDateTime && comparisonValue is DateTime endDateTime)
        {
            bool adjusted = false;

            // Handle day rollover
            if (endDateTime <= startDateTime)
            {
                endDateTime = endDateTime.AddDays(1);
                adjusted = true;
            }

            // If you adjusted, update the model property too
            if (adjusted)
            {
                comparisonProperty.SetValue(instance, endDateTime);
            }

            if (_shouldBeEarlier && startDateTime >= endDateTime)
            {
                return new ValidationResult($"{GetWord(localizationKey2)} يجب ان يكون قبل {GetWord(localizationKey)}.");
            }
            if (!_shouldBeEarlier && startDateTime <= endDateTime)
            {
                return new ValidationResult($"{GetWord(localizationKey2)} يجب ان يكون بعد {GetWord(localizationKey)}.");
            }
        }




        return ValidationResult.Success;
    }
}

