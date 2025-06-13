

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

using System.Linq.Expressions;
using System.Reflection;
using System.Text;


using Qimmah.Models.Common;
using Qimmah.Attributes;

namespace Qimmah.Helpers.HtmlHelpers
{
    public static class CheckBoxHelperExtensions
    {
        public static IHtmlContent JCheckboxFor<TModel, TProperty>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            Dictionary<string, object> textBoxCustomAttributes = null,
            Dictionary<string, object> labelCustomAttributes = null)
        {

            textBoxCustomAttributes ??= new Dictionary<string, object>() { };
            textBoxCustomAttributes.Add("type", "checkbox");
            return htmlHelper.JTextBoxFor(expression, textBoxCustomAttributes, labelCustomAttributes);
        }

        public static IHtmlContent JDays<TModel>(
            this IHtmlHelper<TModel> htmlHelper,
            string InputName = "Days",
            List<DDLViewModel> Days = null,
            List<DDLViewModel> selectedDays = null,
            Dictionary<string, object> textBoxCustomAttributes = null)
        {
            Days = Days.DistinctBy(x => x.Text).Reverse().ToList();

            textBoxCustomAttributes ??= new Dictionary<string, object>();

            Dictionary<int, string> localizationDictionary = htmlHelper.GetLocalization();
            var modelType = htmlHelper.ViewData.Model.GetType(); // Get the model type
            var propertyInfo = modelType.GetRuntimeProperties().FirstOrDefault(x => x.PropertyType == typeof(List<DDLViewModel>)); // Get property info
            var requiredAttribute =
            GetAttributeValue<JRequiredAttribute, (bool IsRequired, int LocalizationKey, string[] Replacee)>(propertyInfo,
            x => (x._isRequired, x._localizationKey, x._replacee));
            var container = new StringBuilder();
            container.AppendLine("<div class='days-container'>");

            string validationField = null;
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
                textBoxCustomAttributes["data-val-required"] = errorMessage;
                validationField = $"<div class=\"invalid-feedback\">{errorMessage}</div>";
            }

            if (textBoxCustomAttributes.ContainsKey("class"))
            {
                textBoxCustomAttributes["class"] += "form-check-input";
            }
            else
            {
                textBoxCustomAttributes["class"] = "form-check-input";
            }

            for (int i = 0; i < Days.Count; i++)
            {
                var dayObject = Days[i];

                var index = $"{InputName}[{i}]";
                var Id = $"{InputName}_{i}";

                var ColContainer = new StringBuilder();
                ColContainer.AppendLine("<div class='day-item'>");

                var checkboxLabel = htmlHelper.Label($"{index}", dayObject.Text, new { @class = "form-check-label" }).GetString();
                ColContainer.AppendLine(checkboxLabel);

                var hiddenIndex = htmlHelper.TextBox($"{index}.Index", i, new { @class = "d-none" }).GetString();
                ColContainer.AppendLine(hiddenIndex);

                var hiddenValue = htmlHelper.TextBox($"{index}.Day", dayObject.Value, new { @class = "d-none" }).GetString();
                ColContainer.AppendLine(hiddenValue);
                textBoxCustomAttributes["id"] = $"{Id}";

                if (selectedDays.IsNotNullOrEmpty() && selectedDays.Select(x => x.Value).Contains(dayObject.Value))
                {
                    textBoxCustomAttributes["checked"] = "checked";
                    var checkboxHtml = htmlHelper.CheckBox($"{index}.Value", htmlAttributes: textBoxCustomAttributes).GetString();
                    ColContainer.AppendLine(checkboxHtml);
                }
                else
                {
                    var checkboxHtml = htmlHelper.CheckBox($"{index}.Value", htmlAttributes: textBoxCustomAttributes).GetString();
                    ColContainer.AppendLine(checkboxHtml);
                }

                ColContainer.AppendLine("</div>");
                container.Append(ColContainer);
            }

            container.AppendLine("</div>");

            return new HtmlString(container.ToString());
        }
    }
}
