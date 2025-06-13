using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Qimmah.Helpers.HtmlHelpers
{
    public static class NumberHelperExtensions
    {
        public static IHtmlContent JNumberFieldFor<TModel, TProperty>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            Dictionary<string, object> textBoxCustomAttributes = null,
            Dictionary<string, object> labelCustomAttributes = null)
        {

            textBoxCustomAttributes ??= new Dictionary<string, object>() { };
            textBoxCustomAttributes.Add("type", "number");
            return htmlHelper.JTextBoxFor(expression, textBoxCustomAttributes,
                labelCustomAttributes);
        }

        public static IHtmlContent JGroupNumberFieldFor<TModel, TProperty>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            Dictionary<string, object> textBoxCustomAttributes = null,
            Dictionary<string, object> labelCustomAttributes = null,
            string prependIcon = null,
            string appendIcon = null)
        {

            textBoxCustomAttributes ??= new Dictionary<string, object>() { };
            textBoxCustomAttributes.Add("type", "number");
            return htmlHelper.JGroupTextBoxFor(expression, textBoxCustomAttributes,
                labelCustomAttributes, prependIcon, appendIcon);
        }
    }
}
