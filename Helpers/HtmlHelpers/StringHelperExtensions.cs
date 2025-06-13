using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;



using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Qimmah.Attributes;
using Qimmah.Models.Localization;


namespace Qimmah.Helpers.HtmlHelpers
{
    public static class StringHelperExtensions
    {
        /// <summary>
        /// Generates a label and input field for a string property with support for custom attributes.
        /// </summary>
        /// <typeparam name="TModel">The model type.</typeparam>
        /// <typeparam name="TProperty">The property type (string).</typeparam>
        /// <param name="htmlHelper">The HTML helper instance.</param>
        /// <param name="expression">An expression to the property.</param>
        /// <param name="textBoxCustomAttributes">Dictionary attributes for the Textbox itself</param>
        /// <param name="labelCustomAttributes">Dictionary attributes for the label of the Textbox</param>
        /// <returns>An IHtmlContent representing the label and input HTML.</returns>
        public static IHtmlContent JTextBoxFor<TModel, TProperty>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            Dictionary<string, object> textBoxCustomAttributes = null,
            Dictionary<string, object> labelCustomAttributes = null)
        {
            Dictionary<int, string> localizationDictionary = htmlHelper.GetLocalization();
            textBoxCustomAttributes ??= new Dictionary<string, object>();
            labelCustomAttributes ??= new Dictionary<string, object>();

            if (textBoxCustomAttributes.ContainsKey("class"))
            {
                textBoxCustomAttributes["class"] = textBoxCustomAttributes["class"] + " form-control ";
            }
            else
            {
                textBoxCustomAttributes.Add("class", " form-control ");
            }


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


            if (!textBoxCustomAttributes.ContainsKey("title"))
            {
                int localizationKey = GetAttributeValue<JLabelAttribute, int>(propertyInfo, x => x.Key);
                // Determine the label text
                string labelText = null;

                if (localizationKey.IsNotNullOrEmpty())
                {
                    localizationDictionary.TryGetValue(localizationKey, out labelText);
                }

                textBoxCustomAttributes.Add("title", labelText);

                if (!textBoxCustomAttributes.ContainsKey("placeholder"))
                {
                    textBoxCustomAttributes.Add("placeholder", labelText);
                }
            }

            // Get property name
            string propertyName = propertyInfo.Name;

            string validationField = null;

            var requiredAttribute =
                GetAttributeValue<JRequiredAttribute, (bool IsRequired, int LocalizationKey, double? maxLength, double? MinLength, double? max, double? min, string[] Replacee)>(propertyInfo,
                    x => (x._isRequired, x._localizationKey, x._maxLength, x._minLength, x._Max, x._Min, x._replacee));
            if (requiredAttribute.IsNotNullOrEmpty() && requiredAttribute.IsRequired)
            {
                // Get the error message from the dictionary using the localization key
                string errorMessage = localizationDictionary != null &&
                                      localizationDictionary.TryGetValue(requiredAttribute.LocalizationKey,
                                          out var message)
                    ? message
                    : "This field is required."; // Fallback message

                if (requiredAttribute.Replacee.IsNotNullOrEmpty() && errorMessage.Contains("{"))
                {
                    for (int i = 0; i < requiredAttribute.Replacee.Length; i++)
                    {
                        errorMessage = errorMessage.Replace($"{{{i}}}", requiredAttribute.Replacee[i]);
                    }
                }

                // Add the `required` attribute to the TextBox attributes
                textBoxCustomAttributes["required"] = "required";
                if (labelCustomAttributes.ContainsKey("class"))
                {
                    labelCustomAttributes["class"] += "required";

                }
                else
                {
                    labelCustomAttributes["class"] = "required";
                }

                textBoxCustomAttributes["data-val-required"] = errorMessage;
                if (requiredAttribute.max.IsNotNullOrEmpty() && requiredAttribute.max != 0)
                {
                    textBoxCustomAttributes["max"] = requiredAttribute.max;

                }
                if (requiredAttribute.min.IsNotNullOrEmpty())
                {
                    textBoxCustomAttributes["min"] = requiredAttribute.min;
                }
                if (requiredAttribute.maxLength.IsNotNullOrEmpty())
                {
                    textBoxCustomAttributes["maxlength"] = requiredAttribute.maxLength;

                }
                if (requiredAttribute.MinLength.IsNotNullOrEmpty())
                {
                    textBoxCustomAttributes["minlength"] = requiredAttribute.MinLength;
                }
                validationField = $"<div class=\"invalid-feedback\">{errorMessage}</div>";

            }

            //var Regex = GetAttributeValues<JRegexPattternAttribute, JRegexPattternAttribute>(propertyInfo, x => x);
            //var HasRegex = Regex.IsNotNullOrEmpty();
            //IHtmlContent RegexConainter = null;

            //if (HasRegex)
            //{
            //    var hasError = htmlHelper.ViewData.ModelState.TryGetValue(propertyName, out var entry)
            //                   && entry.Errors.Any();
            //    var model = htmlHelper.ViewData.Model;

            //    var propertyValue = GetValue(model, expression);

            //    RegexConainter = GenerateValidationMessages(propertyInfo, propertyName, propertyValue: propertyValue, localizationDictionary, Regex);
            //}
            // Generate label
            var label = htmlHelper.JLabelFor(expression, labelCustomAttributes);


            var input = htmlHelper.TextBoxFor(expression, textBoxCustomAttributes);

            // Wrap label and input in a container (optional)
            var html = new HtmlString(
                $"<div  class=\" mb-3 {(requiredAttribute.IsRequired ? "needs-validation" : "")}\">{label.GetString()}{input.GetString()}{validationField}</div>");

            return html;
        }

        public static IHtmlContent JTextBox(
    this IHtmlHelper htmlHelper,
    string name,
    string value = null,
    string labelText = null,
    bool isRequired = false,
    string requiredErrorMessage = null,
    Dictionary<string, object> textBoxCustomAttributes = null,
    Dictionary<string, object> labelCustomAttributes = null,
    Dictionary<string, object> validationMessageCustomAttribues = null)
        {
            var localizationDictionary = htmlHelper.GetLocalization();

            textBoxCustomAttributes ??= new Dictionary<string, object>();
            labelCustomAttributes ??= new Dictionary<string, object>();
            validationMessageCustomAttribues ??= new Dictionary<string, object>();

            // Set up form-control class
            if (textBoxCustomAttributes.ContainsKey("class"))
            {
                textBoxCustomAttributes["class"] = textBoxCustomAttributes["class"] + " form-control ";
            }
            else
            {
                textBoxCustomAttributes.Add("class", " form-control ");
            }

            // Set up title and placeholder if not already specified
            if (!textBoxCustomAttributes.ContainsKey("title") && labelText != null)
            {
                textBoxCustomAttributes.Add("title", labelText);

                if (!textBoxCustomAttributes.ContainsKey("placeholder"))
                {
                    textBoxCustomAttributes.Add("placeholder", labelText);
                }
            }

            string validationField = null;

            // Handle required validation
            if (isRequired)
            {
                string errorMessage = requiredErrorMessage ?? "This field is required.";

                // Add the `required` attribute to the TextBox attributes
                textBoxCustomAttributes["required"] = "required";

                if (labelCustomAttributes.ContainsKey("class"))
                {
                    labelCustomAttributes["class"] += " required";
                }
                else
                {
                    labelCustomAttributes["class"] = "required";
                }

                textBoxCustomAttributes["data-val-required"] = errorMessage;

                if (validationMessageCustomAttribues.ContainsKey("class"))
                {
                    validationMessageCustomAttribues["class"] += " invalid-feedback ";
                }
                else
                {
                    validationMessageCustomAttribues["class"] = " invalid-feedback ";
                }

                string attributes = string.Join(" ", validationMessageCustomAttribues.Select(kv => $"{kv.Key}=\"{kv.Value}\""));

                validationField = $"<div {attributes}>{errorMessage}</div>";
            }

            // Generate label if provided
            string labelHtml = "";
            if (labelText != null)
            {
                var labelBuilder = new TagBuilder("label");
                labelBuilder.Attributes.Add("for", name);

                foreach (var attr in labelCustomAttributes)
                {
                    labelBuilder.Attributes[attr.Key] = attr.Value?.ToString();
                }

                labelBuilder.InnerHtml.Append(labelText);
                labelHtml = labelBuilder.ToHtmlString();
            }

            // Generate input
            var inputBuilder = new TagBuilder("input");
            inputBuilder.Attributes.Add("type", "text");
            inputBuilder.Attributes.Add("id", name);
            inputBuilder.Attributes.Add("name", name);

            if (value != null)
            {
                inputBuilder.Attributes.Add("value", value);
            }

            foreach (var attr in textBoxCustomAttributes)
            {
                inputBuilder.Attributes[attr.Key] = attr.Value?.ToString();
            }

            string inputHtml = inputBuilder.ToHtmlString();

            // Wrap label and input in a container
            var html = new HtmlString(
                $"<div class=\"mb-3 {(isRequired ? "needs-validation" : "")}\">{labelHtml}{inputHtml}{validationField}</div>");

            return html;
        }

        // Extension method for TagBuilder to convert to string
        public static string ToHtmlString(this TagBuilder tagBuilder)
        {
            using (var writer = new StringWriter())
            {
                tagBuilder.WriteTo(writer, HtmlEncoder.Default);
                return writer.ToString();
            }
        }


        public static IHtmlContent JGroupTextBoxFor<TModel, TProperty>(
        this IHtmlHelper<TModel> htmlHelper,
        Expression<Func<TModel, TProperty>> expression,
        Dictionary<string, object> textBoxCustomAttributes = null,
        Dictionary<string, object> labelCustomAttributes = null,
        string prependIcon = null,
        string appendIcon = null)
        {
            var localizationDictionary = htmlHelper.GetLocalization();
            textBoxCustomAttributes ??= new Dictionary<string, object>();
            labelCustomAttributes ??= new Dictionary<string, object>();

            if (textBoxCustomAttributes.ContainsKey("class"))
            {
                textBoxCustomAttributes["class"] = textBoxCustomAttributes["class"] + " form-control ";
            }
            else
            {
                textBoxCustomAttributes.Add("class", " form-control ");
            }

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

            if (!textBoxCustomAttributes.ContainsKey("title"))
            {
                int localizationKey = GetAttributeValue<JLabelAttribute, int>(propertyInfo, x => x.Key);
                // Determine the label text
                string labelText = null;

                if (localizationKey.IsNotNullOrEmpty())
                {
                    localizationDictionary.TryGetValue(localizationKey, out labelText);
                }

                textBoxCustomAttributes.Add("title", labelText);

                if (!textBoxCustomAttributes.ContainsKey("placeholder"))
                {
                    textBoxCustomAttributes.Add("placeholder", labelText);
                }
            }

            // Get property name
            string propertyName = propertyInfo.Name;

            string validationField = null;

            var requiredAttribute =
                GetAttributeValue<JRequiredAttribute, (bool IsRequired, int LocalizationKey, string[] Replacee)>(propertyInfo,
                    x => (x._isRequired, x._localizationKey, x._replacee));
            if (requiredAttribute.IsNotNullOrEmpty() && requiredAttribute.IsRequired)
            {
                // Get the error message from the dictionary using the localization key
                string errorMessage = localizationDictionary != null &&
                                      localizationDictionary.TryGetValue(requiredAttribute.LocalizationKey,
                                          out var message)
                    ? message
                    : "This field is required."; // Fallback message

                if (requiredAttribute.Replacee.IsNotNullOrEmpty() && errorMessage.Contains("{"))
                {
                    for (int i = 0; i < requiredAttribute.Replacee.Length; i++)
                    {
                        errorMessage = errorMessage.Replace($"{{{i}}}", requiredAttribute.Replacee[i]);
                    }
                }

                // Add the `required` attribute to the TextBox attributes
                textBoxCustomAttributes["required"] = "required";
                if (labelCustomAttributes.ContainsKey("class"))
                {
                    labelCustomAttributes["class"] += "required";
                }
                else
                {
                    labelCustomAttributes["class"] = "required";
                }

                textBoxCustomAttributes["data-val-required"] = errorMessage;
                validationField = $"<div class=\"invalid-feedback\">{errorMessage}</div>";
            }

            // Generate label
            var label = htmlHelper.JLabelFor(expression, labelCustomAttributes);

            // Generate input
            var input = htmlHelper.TextBoxFor(expression, textBoxCustomAttributes);

            // Prepare input group HTML if icons are provided
            string inputGroupHtml;
            bool hasInputGroup = !string.IsNullOrEmpty(prependIcon) || !string.IsNullOrEmpty(appendIcon);

            if (hasInputGroup)
            {
                var prependHtml = !string.IsNullOrEmpty(prependIcon)
                    ? $"<span class=\"input-group-text\">{prependIcon}</span>"
                    : "";

                var appendHtml = !string.IsNullOrEmpty(appendIcon)
                    ? $"<span class=\"input-group-text\">{appendIcon}</span>"
                    : "";

                inputGroupHtml = $"<div class=\"input-group\">{prependHtml}{input.GetString()}{appendHtml}{validationField}</div>";
            }
            else
            {
                inputGroupHtml = input.GetString();
            }

            // Wrap label and input in a container
            var html = new HtmlString(
                $"<div class=\"mb-3 {(requiredAttribute.IsRequired ? "needs-validation" : "")}\">{label.GetString()}{inputGroupHtml}</div>");

            return html;
        }

        //public static IHtmlContent GenerateValidationMessages(PropertyInfo propertyInfo, string propertyName,
        //    object propertyValue, Dictionary<string, string> localizationDictionary,
        //    List<JRegexPattternAttribute> regexAttributes)
        //{


        //    // Create a container div for the validation messages
        //    var divContainer = new StringBuilder();

        //    if (regexAttributes != null && regexAttributes.Any())
        //    {
        //        divContainer.AppendLine("<div class='validation-messages'>");

        //        int index = 1;
        //        foreach (var item in regexAttributes)
        //        {
        //            // Get the message from the localization dictionary
        //            string errorMessage = localizationDictionary != null &&
        //                                  localizationDictionary.TryGetValue(item._localizationKey, out var message)
        //                ? message
        //                : "Invalid format."; // Default fallback message
        //            var validationStatus = item.IsValidValue(propertyValue);


        //            // Create a div for each regex pattern with its ID and message
        //            divContainer.AppendLine($@"
        //                <div id=""{propertyName}Validation{index++}"" class=""validation-item"">
        //                    <span class=""validation-message"">{errorMessage}</span>
        //                </div>");
        //        }

        //        divContainer.AppendLine("</div>");
        //    }

        //    return new HtmlString(divContainer.ToString());
        //}

        public static object GetValue<TModel, TProperty>(TModel model, Expression<Func<TModel, TProperty>> expression)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            // Compile the expression into a function
            var compiledExpression = expression.Compile();

            // Use the compiled function to get the property value from the model
            return compiledExpression(model);
        }

        /// <summary>
        /// Generates a label for a model property with localization support.
        /// </summary>
        /// <typeparam name="TModel">The model type.</typeparam>
        /// <typeparam name="TProperty">The property type.</typeparam>
        /// <param name="htmlHelper">The HTML helper instance.</param>
        /// <param name="expression">The expression pointing to the property.</param>
        /// <param name="localizationDictionary">A dictionary containing localization keys and their corresponding values.</param>
        /// <param name="labelCustomAttributes">A Dictionary Containing attributes for the label itself.</param>
        /// <returns>An IHtmlContent for the localized label.</returns>
        public static IHtmlContent JLabelFor<TModel, TProperty>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            Dictionary<string, object> labelCustomAttributes)
        {
            var localizationDictionary = htmlHelper.GetLocalization();

            labelCustomAttributes ??= new Dictionary<string, object>();

            // Get the property info from the expression
            if (!(expression.Body is MemberExpression memberExpression))
            {
                throw new ArgumentException("Expression must be a property.", nameof(expression));
            }

            var propertyInfo = memberExpression.Member as PropertyInfo;
            if (propertyInfo == null)
            {
                throw new ArgumentException("Expression must be a property.", nameof(expression));
            }
            if (labelCustomAttributes.ContainsKey("class"))
            {
                labelCustomAttributes["class"] = labelCustomAttributes["class"] + " form-label";
            }
            else
            {
                labelCustomAttributes.Add("class", " form-label ");
            }

            // Get the localization key from the attribute or the labelCustomAttributes, if it exists

            int localizationKey = GetAttributeValue<JLabelAttribute, int>(propertyInfo, x => x.Key);
            // Determine the label text
            string labelText = null;

            if (labelCustomAttributes.TryGetValue("localizationKey", out var _localizationKey))
            {
                localizationKey = _localizationKey.ToAnyType<int>();
            }
            else
            {
                localizationKey = GetAttributeValue<JLabelAttribute, int>(propertyInfo, x => x.Key);
            }


            if (localizationKey.IsNotNullOrEmpty())
            {
                localizationDictionary.TryGetValue(localizationKey, out labelText);
            }
            else
            {
                labelText = "DICTIONARY IS MISSING";
            }


            // Create and return the label HTML
            return new HtmlString(
                $"<label  for=\"{propertyInfo.Name}\" {ConvertAttributesToHtml(labelCustomAttributes)}>{labelText}</label>");
        }




        public static IHtmlContent JLocalizationInputs<TModel>(
            this IHtmlHelper<TModel> htmlHelper,
            List<FieldLocaliaztionModelBase> localizations,
            string InputName = "lstLocalizations",
            string labelTitle = null,
            Dictionary<string, object> textBoxCustomAttributes = null,
            Dictionary<string, object> labelCustomAttributes = null,
            int LocalizationKey = 38,
            int ColumnWidth = 6)
        {
            textBoxCustomAttributes ??= new Dictionary<string, object>();
            labelCustomAttributes ??= new Dictionary<string, object>();

            var modelType = htmlHelper.ViewData.Model.GetType(); // Get the model type
            var propertyInfo = modelType.GetRuntimeProperties().FirstOrDefault(x => x.PropertyType == typeof(List<FieldLocaliaztionModelBase>)); // Get property info


            var localizationDictionary = htmlHelper.GetLocalization();

            var container = new StringBuilder();

            string validationField = null;

            var requiredAttribute =
                GetAttributeValue<JRequiredAttribute, (bool IsRequired, int LocalizationKey, string[] Replacee)>(propertyInfo,
                    x => (x._isRequired, x._localizationKey, x._replacee));
            if (requiredAttribute.IsNotNullOrEmpty() && requiredAttribute.IsRequired)
            {
                string errorMessage = localizationDictionary != null && localizationDictionary.TryGetValue(requiredAttribute.LocalizationKey, out var message) ? message : "This field is required.";

                if (requiredAttribute.Replacee.IsNotNullOrEmpty() && errorMessage.Contains("{"))
                {
                    for (int i = 0; i < requiredAttribute.Replacee.Length; i++)
                    {
                        errorMessage = errorMessage.Replace($"{{{i}}}", requiredAttribute.Replacee[i]);
                    }
                }

                textBoxCustomAttributes["required"] = "required";
                if (labelCustomAttributes.ContainsKey("class"))
                {
                    labelCustomAttributes["class"] += "required";

                }
                else
                {
                    labelCustomAttributes["class"] = "required";
                }
                textBoxCustomAttributes["data-val-required"] = errorMessage;
                validationField = $"<div class=\"invalid-feedback\">{errorMessage}</div>";
            }


            if (labelCustomAttributes.ContainsKey("class"))
            {
                labelCustomAttributes["class"] += "form-label";
            }
            else
            {
                labelCustomAttributes["class"] = "form-label";
            }

            for (int i = 0; i < localizations.Count; i++)
            {
                var localization = localizations[i];

                string index = $"{InputName}[{i}]";
                string languageName = localization.LanguageName;
                string customClassForInputContainer = "";

                // Generate input fields for each property
                container.AppendLine(GenerateIndexedInput("Index", i.ToString(), IsHidden: true));
                container.AppendLine(GenerateIndexedInput("ContractId", localization.Code, IsHidden: true));
                container.AppendLine(GenerateIndexedInput("Locale", localization.Locale.ToString(), IsHidden: true));
                container.AppendLine(GenerateIndexedInput("Description", localization.Description, isDescription: true));
                container.AppendLine(GenerateIndexedInput("Direction", localization.Direction, IsHidden: true));




                string GenerateIndexedInput(string propertyName, string value, bool isDescription = false, bool IsHidden = false)
                {
                    var inputAttributes = new Dictionary<string, object>(textBoxCustomAttributes ?? new Dictionary<string, object>())
                        {
                            { "value", value }
                        };


                    if (propertyName == "Description")
                    {
                        inputAttributes["placeholder"] = localizationDictionary.TryGetValue(LocalizationKey, out var placeholder)
                            ? string.Format(placeholder, languageName)
                            : $"Enter {propertyName.ToLower()} for {languageName}";
                        inputAttributes["class"] = " form-control  ";
                        customClassForInputContainer += $"col-md-{ColumnWidth}";
                    }

                    //// Add direction attribute for RTL/LTR support
                    //if (isDescription && localization.Direction == "rtl")
                    //{
                    //    inputAttributes["dir"] = "rtl";
                    //}

                    if (IsHidden)
                    {
                        if (inputAttributes.ContainsKey("class"))
                        {
                            inputAttributes["class"] = inputAttributes["class"] + "d-none";
                        }
                        else
                        {
                            inputAttributes["class"] = "d-none";
                        }
                        return htmlHelper.TextBox($"{index}.{propertyName}", inputAttributes["value"], inputAttributes).GetString();


                    }




                    var inputHtml = htmlHelper.TextBox($"{index}.{propertyName}", inputAttributes["value"], inputAttributes);
                    var labelHtml = htmlHelper.Label($"{index}.{propertyName}", $"{(labelTitle.IsNotNullOrEmpty() ? labelTitle : propertyName)} - {languageName}", labelCustomAttributes);

                    return $"<div class=\" mb-3 {customClassForInputContainer}\">{labelHtml.GetString()}{inputHtml.GetString()}{validationField}</div>";
                }
            }

            return new HtmlString(container.ToString());
        }
    }
}
