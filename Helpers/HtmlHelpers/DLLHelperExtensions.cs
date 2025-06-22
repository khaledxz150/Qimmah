using System.Linq.Expressions;
using System.Reflection;
using System.Text;


using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

using Qimmah.Attributes;


namespace Qimmah.Helpers.HtmlHelpers
{
    public static class DLLHelperExtensions
    {
        public class JDropDownListModel<TModel, TOptions>
        {
            public Func<TModel, IEnumerable<TOptions>> optionsProvider { get; set; }
            public Func<TOptions, string> labelSelector { get; set; }
            public Func<TOptions, string> valueSelector { get; set; }
            public Func<TOptions, Dictionary<string, string>> dataSelector { get; set; }
            public Dictionary<string, object> SelectCustomAttributes { get; set; } = new Dictionary<string, object>();
            public Dictionary<string, object> labelCustomAttributes { get; set; } = new Dictionary<string, object>();
        }

        public static IHtmlContent JDropDownSelectFor<TModel, TProperty, TOptions>(
        this IHtmlHelper<TModel> htmlHelper,
        Expression<Func<TModel, TProperty>> expression,
        JDropDownListModel<TModel, TOptions> OptionsModel,
        string SelectedValue = "")

        {
            Dictionary<int, string> localizationDictionary = htmlHelper.GetLocalization();

            if (!(expression.Body is MemberExpression memberExpression))
            {
                throw new ArgumentException("Expression must be a property", nameof(expression));
            }

            var propertyInfo = memberExpression.Member as PropertyInfo;
            if (propertyInfo == null)
            {
                throw new ArgumentException("Expression must be a property", nameof(expression));
            }

            // Property name
            string propertyName = propertyInfo.Name;

            // Add Select2 class
            if (OptionsModel.SelectCustomAttributes.ContainsKey("class"))
            {
                OptionsModel.SelectCustomAttributes["class"] += " form-select form-control select2 form-select-lg mb-3";
            }
            else
            {
                OptionsModel.SelectCustomAttributes["class"] = " form-select form-control select2 form-select-lg mb-3";
            }

            // Handle required validation
            string validationField = null;
            var requiredAttribute = GetAttributeValue<JRequiredAttribute, (bool IsRequired, int LocalizationKey)>(
                propertyInfo, x => (x._isRequired, x._localizationKey));

            if (requiredAttribute.IsNotNullOrEmpty() && requiredAttribute.IsRequired)
            {
                // Get the error message from the dictionary
                string errorMessage = localizationDictionary != null && localizationDictionary.TryGetValue(requiredAttribute.LocalizationKey, out var message)
                    ? message
                    : "This field is required."; // Default error message

                // Add required attributes
                OptionsModel.SelectCustomAttributes["required"] = "required";
                OptionsModel.labelCustomAttributes["class"] = "required";
                OptionsModel.SelectCustomAttributes["data-val-required"] = errorMessage;

                // Validation feedback
                validationField = $"<div class=\"invalid-feedback\">{errorMessage}</div>";
            }

            var LocalizationAttribute = GetAttributeValue<JLabelAttribute, int?>(
                propertyInfo, x => x.Key);
            IHtmlContent labelHtml = null;

            if (LocalizationAttribute.IsNotNullOrEmpty())
            {
                labelHtml = htmlHelper.JLabelFor(expression, OptionsModel.labelCustomAttributes);
            }


            // Build dropdown options
            var optionsHtml = new StringBuilder();
            var model = htmlHelper.ViewData.Model;
            var options = OptionsModel.optionsProvider(model);
            optionsHtml.AppendLine($"<option ></option>");

            if (options.IsNotNullOrEmpty())
            {
                foreach (var option in options)
                {
                    var value = OptionsModel.valueSelector(option);
                    var displayText = OptionsModel.labelSelector(option);
                    var attributes = new StringBuilder($"value=\"{value}\"");

                    if (OptionsModel.dataSelector is not null)
                    {
                        var dataAttributes = OptionsModel.dataSelector(option);

                        if (dataAttributes != null)
                        {
                            foreach (var attr in dataAttributes)
                            {
                                attributes.Append($" {attr.Key}=\"{attr.Value}\"");
                            }
                        }
                    }

                    if (SelectedValue == value)
                    {
                        attributes.Append($" selected ");
                    }


                    optionsHtml.AppendLine($"<option {attributes}>{displayText}</option>");
                }

            }



            // Generate dropdown
            var dropdownHtml = $@"<select name=""{propertyName}"" id=""{propertyName}"" {ConvertAttributesToHtml(OptionsModel.SelectCustomAttributes)}> {optionsHtml} </select>";

            // Wrap everything
            var html = $@"
                 <div class='mb-3 {(requiredAttribute.IsRequired ? "needs-validation" : "")}'>
                     {labelHtml.GetString()}
                     {dropdownHtml}
                     {validationField}
                 </div>";

            return new HtmlString(html);
        }



        public static IHtmlContent JDropDownMultiSelectFor<TModel, TProperty, TOptions>(
                this IHtmlHelper<TModel> htmlHelper,
                Expression<Func<TModel, TProperty>> expression,
                JDropDownListModel<TModel, TOptions> OptionsModel,
                List<string> SelectedValues = null,
                string SelectedValue = null)
        {
            Dictionary<int, string> localizationDictionary = htmlHelper.GetLocalization();

            OptionsModel.SelectCustomAttributes ??= new Dictionary<string, object>();
            OptionsModel.labelCustomAttributes ??= new Dictionary<string, object>();

            if (!(expression.Body is MemberExpression memberExpression))
            {
                throw new ArgumentException("Expression must be a property", nameof(expression));
            }

            var propertyInfo = memberExpression.Member as PropertyInfo;
            if (propertyInfo == null)
            {
                throw new ArgumentException("Expression must be a property", nameof(expression));
            }

            // Property name
            string propertyName = propertyInfo.Name;

            // Localization for label
            var labelLocalizationKey = GetAttributeValue<JLabelAttribute, int>(propertyInfo, x => x.Key);
            string labelText = "";
            if (labelLocalizationKey.IsNotNullOrEmpty())
            {
                labelText = localizationDictionary.TryGetValue(labelLocalizationKey, out var localizedLabel) ? localizedLabel : propertyName;
            }

            // Add Select2 classes for multi-select
            if (OptionsModel.SelectCustomAttributes.ContainsKey("class"))
            {
                OptionsModel.SelectCustomAttributes["class"] += " d-none form-select select2 select2-multiple form-select-lg mb-3";
            }
            else
            {
                OptionsModel.SelectCustomAttributes["class"] = "d-none form-select select2 select2-multiple form-select-lg mb-3";
            }

            // Handle required validation
            string validationField = null;
            var requiredAttribute = GetAttributeValue<JRequiredAttribute, (bool IsRequired, int LocalizationKey)>(
                propertyInfo, x => (x._isRequired, x._localizationKey));

            if (requiredAttribute.IsNotNullOrEmpty() && requiredAttribute.IsRequired)
            {
                // Get the error message from the dictionary
                string errorMessage = localizationDictionary != null && localizationDictionary.TryGetValue(requiredAttribute.LocalizationKey, out var message)
                    ? message
                    : "This field is required."; // Default error message

                // Add required attributes
                OptionsModel.SelectCustomAttributes["required"] = "required";
                OptionsModel.labelCustomAttributes["class"] = "required";
                OptionsModel.SelectCustomAttributes["data-val-required"] = errorMessage;

                // Validation feedback
                validationField = $"<div class=\"invalid-feedback\">{errorMessage}</div>";
            }

            // Generate label
            IHtmlContent labelHtml = null;
            if (labelText.IsNotNullOrEmpty())
            {
                labelHtml = htmlHelper.LabelFor(expression, labelText, OptionsModel.labelCustomAttributes);
            }

            // Build dropdown options
            // var optionsHtml = new StringBuilder();
            var model = htmlHelper.ViewData.Model;
            var options = OptionsModel.optionsProvider(model);
            // optionsHtml.AppendLine($"<option >{localizationDictionary[114]}</option>");


            if (options.IsNotNullOrEmpty())
            {
                foreach (var option in options)
                {
                    var value = OptionsModel.valueSelector(option);
                    var displayText = OptionsModel.labelSelector(option);
                    var dataAttributes = OptionsModel.dataSelector(option);

                    var attributes = new StringBuilder($"value=\"{value}\"");
                    if (SelectedValues.IsNotNullOrEmpty() && SelectedValues.Contains(value))
                    {
                        attributes.Append($" selected ");
                    }

                    if (SelectedValue.IsNotNullOrEmpty() && SelectedValue == value)
                    {
                        attributes.Append($" selected ");
                    }

                    if (dataAttributes != null)
                    {
                        foreach (var attr in dataAttributes)
                        {
                            attributes.Append($" {attr.Key}=\"{attr.Value}\"");
                        }
                    }


                    // optionsHtml.AppendLine($"<option {attributes}>{displayText}</option>");
                }
            }

            // Generate dropdown with multiple attribute
            // var dropdownHtml = $@"<select name=""{propertyName}"" id=""{propertyName}"" multiple {ConvertAttributesToHtml(OptionsModel.SelectCustomAttributes)}> {optionsHtml} </select>";
            var dropdownHtml = $@"<select name=""{propertyName}"" id=""{propertyName}"" multiple {ConvertAttributesToHtml(OptionsModel.SelectCustomAttributes)}> </select>";

            // Wrap everything
            var html = $@"
            <div class='mb-3 {(requiredAttribute.IsRequired ? "needs-validation" : "")}'>
                {labelHtml.GetString()}
                {dropdownHtml}
                {validationField}
            </div>";

            return new HtmlString(html);
        }

        public static IHtmlContent JDropDownMultiSelect<TModel, TOptions>(
            this IHtmlHelper<TModel> htmlHelper,
            string name,
            JDropDownListModel<TModel, TOptions> OptionsModel,
            List<string> SelectedValues = null,
            string SelectedValue = null,
            string labelText = null,
            bool isRequired = false,
            string requiredErrorMessage = null,
            string permanentLabel = null)
        {
            Dictionary<int, string> localizationDictionary = htmlHelper.GetLocalization();

            OptionsModel.SelectCustomAttributes ??= new Dictionary<string, object>();
            OptionsModel.labelCustomAttributes ??= new Dictionary<string, object>();

            // Add Select2 classes for multi-select
            if (OptionsModel.SelectCustomAttributes.ContainsKey("class"))
            {
                OptionsModel.SelectCustomAttributes["class"] += " form-select select2 select2-multiple form-select-lg mb-3";
            }
            else
            {
                OptionsModel.SelectCustomAttributes["class"] = " form-select select2 select2-multiple form-select-lg mb-3";
            }

            // Add permanent label as data attribute if provided
            if (permanentLabel.IsNotNullOrEmpty())
            {
                OptionsModel.SelectCustomAttributes["data-permanent-label"] = permanentLabel;
            }

            // Handle required validation
            string validationField = null;
            if (isRequired)
            {
                string errorMessage = requiredErrorMessage ?? "This field is required.";

                // Add required attributes
                OptionsModel.SelectCustomAttributes["required"] = "required";
                OptionsModel.labelCustomAttributes["class"] = "required";
                OptionsModel.SelectCustomAttributes["data-val-required"] = errorMessage;

                // Validation feedback
                validationField = $"<div class=\"invalid-feedback\">{errorMessage}</div>";
            }

            // Generate label
            IHtmlContent labelHtml = null;
            if (labelText.IsNotNullOrEmpty())
            {
                var labelTag = new TagBuilder("label");
                labelTag.Attributes["for"] = name;
                labelTag.InnerHtml.SetContent(labelText);

                // Add label attributes
                foreach (var attr in OptionsModel.labelCustomAttributes)
                {
                    labelTag.Attributes[attr.Key] = attr.Value?.ToString();
                }

                labelHtml = labelTag;
            }

            // Build dropdown options
            var optionsHtml = new StringBuilder();
            var model = htmlHelper.ViewData.Model;
            var options = OptionsModel.optionsProvider(model);

            if (options.IsNotNullOrEmpty())
            {
                foreach (var option in options)
                {
                    var value = OptionsModel.valueSelector(option);
                    var displayText = OptionsModel.labelSelector(option);
                    var dataAttributes = OptionsModel.dataSelector(option);

                    var attributes = new StringBuilder($"value=\"{value}\"");

                    // Check if this option should be selected
                    if (SelectedValues.IsNotNullOrEmpty() && SelectedValues.Contains(value))
                    {
                        attributes.Append(" selected");
                    }

                    if (SelectedValue.IsNotNullOrEmpty() && SelectedValue == value)
                    {
                        attributes.Append(" selected");
                    }

                    if (dataAttributes != null)
                    {
                        foreach (var attr in dataAttributes)
                        {
                            attributes.Append($" {attr.Key}=\"{attr.Value}\"");
                        }
                    }

                    optionsHtml.AppendLine($"<option {attributes}>{displayText}</option>");
                }
            }

            // Generate dropdown with multiple attribute
            var dropdownHtml = $"<select name=\"{name}\" id=\"{name}\" multiple {ConvertAttributesToHtml(OptionsModel.SelectCustomAttributes)}>{optionsHtml}</select>";

            // Wrap everything
            var html = $@"
    <div class='mb-3 {(isRequired ? "needs-validation" : "")}'>
        {labelHtml?.GetString()}
        {dropdownHtml}
        {validationField}
    </div>";

            return new HtmlString(html);
        }
    }
}
