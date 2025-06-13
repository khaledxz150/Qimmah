//using System.ComponentModel.DataAnnotations;
//using Microsoft.Extensions.DependencyInjection;
//using System.Text.RegularExpressions;
//using WasteManagement.Models.Localization.Protos;
//using WasteManagement.Framework.Wrapper;

//namespace WasteManagement.Framework.Attributes;

//[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
//public class JRegexPattternAttribute : RequiredAttribute
//{
//    public readonly string _RegexPattern;
//    public readonly int _localizationKey;

//    public JRegexPattternAttribute(string regexPattern, int localizationKey)
//    {
//        _RegexPattern = regexPattern;
//        _localizationKey = localizationKey;
//    }


//    public bool IsValidValue(object Value)
//    {
//        return new Regex(_RegexPattern).IsMatch(Value.ToString());
//    }

//    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
//    {
//        var wrapper = validationContext.GetRequiredService<GrpcServicesWrapper>();
//        var response = wrapper.DictionaryLocalizationClient.GetDictionaryLocalizationAsync(new DictionaryRequest()
//        {
//            LstIDs = { _localizationKey },
//            LstIDsLength = 1
//        }).GetAwaiter().GetResult();
//        //var isValid = new Regex(_RegexPattern).IsMatch(value.ToString());
//        //if (isValid)
//        //{
//        //    return ValidationResult.Success;
//        //}

//        return new ValidationResult(response.Items?[_localizationKey] ?? "");
//    }
//}