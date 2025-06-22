using System.Text;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Qimmah.Helpers.HtmlHelpers
{
    public static class RatingDisplayHelperExtensions
    {
        public static IHtmlContent RatingDisplay(
        this IHtmlHelper html,
        double rating,
        string count,
        string reviewWord)
        {
            var sb = new StringBuilder();
            sb.Append("<div class='rating-display'>");

            // 1. Stars
            sb.Append("<span class='stars'>");
            for (int i = 1; i <= 5; i++)
            {
                if (rating >= i)
                {
                    sb.Append("<span class='star'>&#9733;</span>");
                }
                else if (rating > i - 1)
                {
                    double percent = (rating - (i - 1)) * 100;
                    sb.Append($@"
<span class='star star-partial'>
  <span class='star-fill' style='width:{percent}%; overflow:hidden; display:inline-block;'>&#9733;</span>
  <span class='star-empty'>&#9733;</span>
</span>");
                }
                else
                {
                    sb.Append("<span class='star empty'>&#9733;</span>");
                }
            }
            sb.Append("</span>");

            // 2. Count and review word
            sb.AppendFormat("<span class='rating-count'>({0} {1})</span>", count, reviewWord);

            // 3. Rating value
            sb.AppendFormat("<span class='rating-value'>{0:F2}</span>", rating);

            sb.Append("</div>");
            return new HtmlString(sb.ToString());
        }
    }
}
