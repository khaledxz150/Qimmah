using System.Linq.Expressions;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

using System.Text;
namespace Qimmah.Helpers.HtmlHelpers
{
    public static class DateTimeHelperExtensions
    {
        public static IHtmlContent JDatetimeFor<TModel, TProperty>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            Dictionary<string, object> textBoxCustomAttributes = null,
            Dictionary<string, object> labelCustomAttributes = null)
        {

            textBoxCustomAttributes ??= new Dictionary<string, object>() { };
            textBoxCustomAttributes.Add("type", "Datetime-local");
            return htmlHelper.JTextBoxFor(expression, textBoxCustomAttributes,
                labelCustomAttributes);
        }

        public static IHtmlContent JDateFor<TModel, TProperty>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            Dictionary<string, object> textBoxCustomAttributes = null,
            Dictionary<string, object> labelCustomAttributes = null)
        {

            textBoxCustomAttributes ??= new Dictionary<string, object>() { };
            textBoxCustomAttributes.Add("type", "Date");
            return htmlHelper.JTextBoxFor(expression, textBoxCustomAttributes,
                labelCustomAttributes);
        }

        public static IHtmlContent JTimeFor<TModel, TProperty>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            Dictionary<string, object> textBoxCustomAttributes = null,
            Dictionary<string, object> labelCustomAttributes = null)
        {
            textBoxCustomAttributes ??= new Dictionary<string, object>() { };
            textBoxCustomAttributes.Add("type", "Time");
            return htmlHelper.JTextBoxFor(expression, textBoxCustomAttributes,
                labelCustomAttributes);
        }

        //public static IHtmlContent JTimeFor<TModel, TProperty>(
        //    this IHtmlHelper<TModel> htmlHelper,
        //    Expression<Func<TModel, TProperty>> expression,
        //    Dictionary<string, object> textBoxCustomAttributes = null,
        //    Dictionary<string, object> labelCustomAttributes = null) 
        //{
        //    textBoxCustomAttributes ??= new Dictionary<string, object>();

        //    var modelExplorer = expression.Compile();
        //    string name = htmlHelper.NameFor(expression);
        //    string id = htmlHelper.IdFor(expression);
        //    string value = htmlHelper.ValueFor(expression)?.ToString() ?? "";
        //    //string label = modelExplorer.Metadata.DisplayName ?? name;
        //    var label = "";

        //    var timePickerHtml = $@"
        //<div class='input-field'>
        //    <input type='text' id='{id}' name='{name}' class='timepicker' value='{value}'>
        //    <label for='{id}'>{label}</label>
        //</div>
        //<script>
        //    document.addEventListener('DOMContentLoaded', function() {{
        //        var elems = document.querySelectorAll('.timepicker');
        //        M.Timepicker.init(elems, {{
        //            twelveHour: false, // 24-hour format
        //            autoClose: true
        //        }});
        //    }});
        //</script>";

        //    return new HtmlString(timePickerHtml);
        //}


    }
}
