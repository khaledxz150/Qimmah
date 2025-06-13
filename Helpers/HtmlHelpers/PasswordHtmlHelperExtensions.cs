using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;
using Qimmah.Attributes;
using Qimmah.Helpers;

namespace Qimmah.Helpers.HtmlHelpers;

public static class PasswordHtmlHelperExtensions
{
    public static IHtmlContent JPasswordFor<TModel, TProperty>(
        this IHtmlHelper<TModel> htmlHelper,
        Expression<Func<TModel, TProperty>> expression,
        Dictionary<string, object> passwordCustomAttributes = null,
        Dictionary<string, object> labelCustomAttributes = null,
        bool showRequirements = true,
        bool showStrengthMeter = true)
    {
        Dictionary<int, string> localizationDictionary = htmlHelper.GetLocalization();
        passwordCustomAttributes ??= new Dictionary<string, object>();
        labelCustomAttributes ??= new Dictionary<string, object>();

        // Add password-specific classes
        if (passwordCustomAttributes.ContainsKey("class"))
        {
            passwordCustomAttributes["class"] = passwordCustomAttributes["class"] + " form-control password-input ";
        }
        else
        {
            passwordCustomAttributes.Add("class", " form-control password-input ");
        }

        // Ensure it's a password type
        passwordCustomAttributes["type"] = "password";

        // Get property info from the expression
        if (!(expression.Body is MemberExpression memberExpression))
        {
            throw new ArgumentException("Expression must be a property", nameof(expression));
        }

        var propertyInfo = memberExpression.Member as PropertyInfo;
        if (propertyInfo == null)
        {
            throw new ArgumentException("Expression must be a property", nameof(expression));
        }

        string propertyName = propertyInfo.Name;
        string fieldId = $"{propertyName}";

        // Get label information
        if (!passwordCustomAttributes.ContainsKey("title"))
        {
            int localizationKey = GetAttributeValue<JLabelAttribute, int>(propertyInfo, x => x.Key);
            string localizedLabelText = null;

            if (localizationKey != 0)
            {
                localizationDictionary.TryGetValue(localizationKey, out localizedLabelText);
            }

            if (!string.IsNullOrEmpty(localizedLabelText))
            {
                passwordCustomAttributes.Add("title", localizedLabelText);
                if (!passwordCustomAttributes.ContainsKey("placeholder"))
                {
                    passwordCustomAttributes.Add("placeholder", localizedLabelText);
                }
            }
        }

        // Get password attribute and validation rules
        var passwordAttribute = propertyInfo.GetCustomAttribute<JPasswordAttribute>();
        var requiredAttribute = GetAttributeValue<JRequiredAttribute, (bool IsRequired, int LocalizationKey, double? maxLength, double? MinLength, double? max, double? min, string[] Replacee)>(
            propertyInfo, x => (x._isRequired, x._localizationKey, x._maxLength, x._minLength, x._Max, x._Min, x._replacee));

        string validationField = "";
        var passwordRules = new Dictionary<string, object>();

        // Handle required validation
        if (requiredAttribute.IsRequired)
        {
            string errorMessage = localizationDictionary != null &&
                                  localizationDictionary.TryGetValue(requiredAttribute.LocalizationKey, out var message)
                ? message
                : "This field is required.";

            if (requiredAttribute.Replacee?.Length > 0 && errorMessage.Contains("{"))
            {
                for (int i = 0; i < requiredAttribute.Replacee.Length; i++)
                {
                    errorMessage = errorMessage.Replace($"{{{i}}}", requiredAttribute.Replacee[i]);
                }
            }

            passwordCustomAttributes["required"] = "required";
            passwordCustomAttributes["data-val-required"] = errorMessage;

            if (labelCustomAttributes.ContainsKey("class"))
            {
                labelCustomAttributes["class"] += " required";
            }
            else
            {
                labelCustomAttributes["class"] = "required";
            }

            validationField = $"<div class=\"invalid-feedback\">{errorMessage}</div>";
        }

        // Handle password-specific validation
        if (passwordAttribute != null)
        {
            passwordRules = passwordAttribute.GetValidationRules();

            // Add HTML5 constraints
            passwordCustomAttributes["minlength"] = passwordAttribute._minLength;
            passwordCustomAttributes["maxlength"] = passwordAttribute._maxLength;

            // Add data attributes for JavaScript validation with localized messages
            passwordCustomAttributes["data-password-rules"] = JsonSerializer.Serialize(passwordRules);

            // Add localized validation messages
            var validationMessages = new Dictionary<string, string>();
            if (localizationDictionary != null)
            {
                validationMessages["weakPassword"] = localizationDictionary.TryGetValue(171, out var weakMsg) ? weakMsg : "Password is too weak";
                validationMessages["passwordMismatch"] = localizationDictionary.TryGetValue(168, out var mismatchMsg) ? mismatchMsg : "Passwords do not match";
                validationMessages["showPassword"] = localizationDictionary.TryGetValue(169, out var showMsg) ? showMsg : "Show password";
                validationMessages["hidePassword"] = localizationDictionary.TryGetValue(170, out var hideMsg) ? hideMsg : "Hide password";
                validationMessages["veryWeak"] = localizationDictionary.TryGetValue(163, out var vwMsg) ? vwMsg : "Very Weak";
                validationMessages["weak"] = localizationDictionary.TryGetValue(164, out var wMsg) ? wMsg : "Weak";
                validationMessages["fair"] = localizationDictionary.TryGetValue(165, out var fMsg) ? fMsg : "Fair";
                validationMessages["good"] = localizationDictionary.TryGetValue(166, out var gMsg) ? gMsg : "Good";
                validationMessages["strong"] = localizationDictionary.TryGetValue(167, out var sMsg) ? sMsg : "Strong";
            }

            passwordCustomAttributes["data-validation-messages"] = System.Net.WebUtility.HtmlEncode(JsonSerializer.Serialize(validationMessages));

        }
        else
        {
            // Default password rules if no attribute is specified
            passwordRules = new Dictionary<string, object>
            {
                ["minLength"] = 8,
                ["maxLength"] = 128,
                ["requireUppercase"] = true,
                ["requireLowercase"] = true,
                ["requireDigits"] = true,
                ["requireSpecialChars"] = true,
                ["minUppercase"] = 1,
                ["minLowercase"] = 1,
                ["minDigits"] = 1,
                ["minSpecialChars"] = 1
            };
            passwordCustomAttributes["data-password-rules"] = JsonSerializer.Serialize(passwordRules);

            // Add default localized validation messages
            var validationMessages = new Dictionary<string, string>();
            if (localizationDictionary != null)
            {
                validationMessages["weakPassword"] = localizationDictionary.TryGetValue(171, out var weakMsg) ? weakMsg : "Password is too weak";
                validationMessages["passwordMismatch"] = localizationDictionary.TryGetValue(168, out var mismatchMsg) ? mismatchMsg : "Passwords do not match";
                validationMessages["showPassword"] = localizationDictionary.TryGetValue(169, out var showMsg) ? showMsg : "Show password";
                validationMessages["hidePassword"] = localizationDictionary.TryGetValue(170, out var hideMsg) ? hideMsg : "Hide password";
                validationMessages["veryWeak"] = localizationDictionary.TryGetValue(163, out var vwMsg) ? vwMsg : "Very Weak";
                validationMessages["weak"] = localizationDictionary.TryGetValue(164, out var wMsg) ? wMsg : "Weak";
                validationMessages["fair"] = localizationDictionary.TryGetValue(165, out var fMsg) ? fMsg : "Fair";
                validationMessages["good"] = localizationDictionary.TryGetValue(166, out var gMsg) ? gMsg : "Good";
                validationMessages["strong"] = localizationDictionary.TryGetValue(167, out var sMsg) ? sMsg : "Strong";
            }
            passwordCustomAttributes["data-validation-messages"] = System.Net.WebUtility.HtmlEncode(JsonSerializer.Serialize(validationMessages));
        }

        // Generate the HTML
        var htmlContent = new System.Text.StringBuilder();

        // Label
        var labelText = passwordCustomAttributes.ContainsKey("title") ? passwordCustomAttributes["title"].ToString() : propertyName;
        var labelAttributes = string.Join(" ", labelCustomAttributes.Select(kvp => $"{kvp.Key}=\"{kvp.Value}\""));
        htmlContent.AppendLine($"<label for=\"{fieldId}\" {labelAttributes}>{labelText}</label>");

        // Password input wrapper
        htmlContent.AppendLine("<div class=\"password-input-wrapper position-relative\">");

        // Password input
        var inputAttributes = string.Join(" ", passwordCustomAttributes.Select(kvp => $"{kvp.Key}=\"{kvp.Value}\""));
        htmlContent.AppendLine($"<input id=\"{fieldId}\" name=\"{propertyName}\" {inputAttributes} />");

        // Toggle visibility button
        var showPasswordText = localizationDictionary?.TryGetValue(169, out var showMsg2) == true ? showMsg2 : "Show password";
        // htmlContent.AppendLine($"<button type=\"button\" class=\"btn btn-outline-secondary password-toggle\" data-target=\"{fieldId}\" title=\"{showPasswordText}\">");
        // htmlContent.AppendLine("<i class=\"fas fa-eye\"></i>");
        // htmlContent.AppendLine("</button>");

        htmlContent.AppendLine("</div>");

        // Validation feedback
        htmlContent.AppendLine(validationField);

        // Password strength meter
        if (showStrengthMeter)
        {
            htmlContent.AppendLine($"<div class=\"password-strength-meter mt-2\" data-target=\"{fieldId}\">");
            htmlContent.AppendLine("<div class=\"strength-bar\">");
            htmlContent.AppendLine("<div class=\"strength-fill\"></div>");
            htmlContent.AppendLine("</div>");
            htmlContent.AppendLine("<div class=\"strength-text\"></div>");
            htmlContent.AppendLine("</div>");
        }

        // Password requirements
        if (showRequirements)
        {
            var requirementsText = localizationDictionary?.TryGetValue(157, out var reqMsg) == true ? reqMsg : "Password must contain:";
            htmlContent.AppendLine($"<div class=\"password-requirements mt-2\" data-target=\"{fieldId}\">");
            htmlContent.AppendLine($"<small class=\"text-muted\">{requirementsText}</small>");
            htmlContent.AppendLine("<ul class=\"password-requirements-list\">");

            var requirements = passwordAttribute?.GetPasswordRequirements(localizationDictionary) ?? new List<string>();

            // If no specific requirements from attribute, build from localization
            if (requirements.Count == 0)
            {
                var minLen = (int)(passwordRules.ContainsKey("minLength") ? passwordRules["minLength"] : 8);
                var maxLen = (int)(passwordRules.ContainsKey("maxLength") ? passwordRules["maxLength"] : 128);

                if (localizationDictionary != null)
                {
                    if (localizationDictionary.TryGetValue(158, out var lengthReq))
                        requirements.Add(lengthReq.Replace("{0}", minLen.ToString()).Replace("{1}", maxLen.ToString()));

                    if ((bool)(passwordRules.ContainsKey("requireUppercase") ? passwordRules["requireUppercase"] : true) &&
                        localizationDictionary.TryGetValue(159, out var upperReq))
                    {
                        var minUpper = passwordRules.ContainsKey("minUppercase") ? passwordRules["minUppercase"].ToString() : "1";
                        requirements.Add(upperReq.Replace("{0}", minUpper));
                    }

                    if ((bool)(passwordRules.ContainsKey("requireLowercase") ? passwordRules["requireLowercase"] : true) &&
                        localizationDictionary.TryGetValue(160, out var lowerReq))
                    {
                        var minLower = passwordRules.ContainsKey("minLowercase") ? passwordRules["minLowercase"].ToString() : "1";
                        requirements.Add(lowerReq.Replace("{0}", minLower));
                    }

                    if ((bool)(passwordRules.ContainsKey("requireDigits") ? passwordRules["requireDigits"] : true) &&
                        localizationDictionary.TryGetValue(161, out var digitReq))
                    {
                        var minDigits = passwordRules.ContainsKey("minDigits") ? passwordRules["minDigits"].ToString() : "1";
                        requirements.Add(digitReq.Replace("{0}", minDigits));
                    }

                    if ((bool)(passwordRules.ContainsKey("requireSpecialChars") ? passwordRules["requireSpecialChars"] : true) &&
                        localizationDictionary.TryGetValue(162, out var specialReq))
                    {
                        var minSpecial = passwordRules.ContainsKey("minSpecialChars") ? passwordRules["minSpecialChars"].ToString() : "1";
                        requirements.Add(specialReq.Replace("{0}", minSpecial));
                    }
                }
            }

            foreach (var requirement in requirements)
            {
                htmlContent.AppendLine($"<li class=\"requirement-item\">{requirement}</li>");
            }

            htmlContent.AppendLine("</ul>");
            htmlContent.AppendLine("</div>");
        }

        return new HtmlString(htmlContent.ToString());
    }

    private static TValue GetAttributeValue<TAttribute, TValue>(PropertyInfo propertyInfo, Func<TAttribute, TValue> valueSelector)
        where TAttribute : Attribute
    {
        var attribute = propertyInfo.GetCustomAttribute<TAttribute>();
        return attribute != null ? valueSelector(attribute) : default(TValue);
    }
}