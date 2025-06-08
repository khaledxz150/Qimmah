using System.Text.Json;

namespace Qimmah.Extensions
{
    public static class JsonExtensions
    {
        public static string ToJson<T>(this List<T> list)
        {
            return JsonSerializer.Serialize(list);
        }
    }
}