using System.Reflection;

using Qimmah.Extensions;
using Qimmah.Security.Attributes;

namespace Qimmah.Security;

/*Khaled : this should be seen only by gRPC*/
public static class CurrentUserManager
{
    private static readonly Dictionary<string, Action<UserPrinciple, string>> PropertySetters = new();

    public static IHttpContextAccessor CurrentContextAccessor { get; set; }
    public static UserPrinciple __CurrentUser
    {
        get
        {
            var context = CurrentContextAccessor.HttpContext;
            if (context.Items.ContainsKey("CurrentUser"))
            {
                return (UserPrinciple)context.Items["CurrentUser"];
            }

            var currentUser = CreateCurrentUser();
            context.Items["CurrentUser"] = currentUser;
            return currentUser;
        }
    }
    public static long TenantID { get { return CurrentContextAccessor.HttpContext!.User.Claims.FirstOrDefault(x => x.Type == "TenantID")!.Value.ToAnyType<long>(); } }

    static CurrentUserManager()
    {
        CurrentContextAccessor = new HttpContextAccessor();

        var properties = typeof(UserPrinciple).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var prop in properties)
        {
            var attribute = prop.GetCustomAttribute<ClaimMapperAttribute>();
            if (attribute is not null)
            {
                PropertySetters[attribute.ClaimType] = CreateSetter(prop);
            }
        }
    }

    private static UserPrinciple CreateCurrentUser()
    {
        var principal = CurrentContextAccessor.HttpContext?.User;
        var userTicket = new UserPrinciple();

        if (principal is null || principal.Identity?.IsAuthenticated is false)
        {
            /*this needs to be enhanced*/
            userTicket.LanguageID = GetLanguageIdFromHeader() ?? GetLanguageIdFromLocalCookie();
            return userTicket;
        }

        foreach (var claim in principal.Claims)
        {
            if (PropertySetters.TryGetValue(claim.Type, out var setter) && !string.IsNullOrEmpty(claim.Value))
            {
                try
                {
                    setter(userTicket, claim.Value);
                }
                catch (Exception e)
                {
                }
            }
        }

        return userTicket;
    }

    private static Action<UserPrinciple, string> CreateSetter(PropertyInfo prop)
    {
        return prop.PropertyType switch
        {
            Type t when t == typeof(string) => (user, value) => prop.SetValue(user, value),
            Type t when t == typeof(int) => (user, value) => prop.SetValue(user, int.Parse(value)),
            Type t when t == typeof(bool) => (user, value) => prop.SetValue(user, bool.Parse(value)),
            Type t when t.IsEnum => (user, value) => prop.SetValue(user, Enum.Parse(t, value)),
            _ => (user, value) => prop.SetValue(user, Convert.ChangeType(value, prop.PropertyType))
        };
    }


    public static int GetLanguageIdFromLocalCookie()
    {
        var cookieValue = CurrentContextAccessor.HttpContext?.Request.Cookies["LanguageID"];
        return int.TryParse(cookieValue, out int languageId) ? languageId : 2;
    }

    public static string GetLanguageNameFromLocalCookie()
    {
        var cookieValue = CurrentContextAccessor.HttpContext?.Request.Cookies["Name"];
        return cookieValue.IsNotNullOrEmpty() ? cookieValue : "ar";
    }

    public static string GetActiveTabLocalCookie()
    {
        var cookieValue = CurrentContextAccessor.HttpContext?.Request.Cookies["ActiveTab"];
        return cookieValue.IsNotNullOrEmpty() ? cookieValue : "Home";
    }

    public static string GetLanguageDirectionFromLocalCookie()
    {
        var cookieValue = CurrentContextAccessor.HttpContext?.Request.Cookies["Direction"];
        return cookieValue.IsNotNullOrEmpty() ? cookieValue : "rtl";
    }

    public static int? GetLanguageIdFromHeader()
    {
        var cookieValue = CurrentContextAccessor.HttpContext?.Request.Headers["LanguageID"];
        return int.TryParse(cookieValue, out int languageId) ? languageId : 2;
    }

    public static void SetLanguageIdInLocalCookie(int languageId, string Direction = "rtl", string Name = "ar")
    {
        try
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTimeOffset.UtcNow.AddDays(30)
            };

            var dictionary = new KeyValuePair<string, string>[3];
            dictionary[0] = new("LocalLanguage", languageId.ToString());

            if (Direction.IsNotNullOrEmpty())
            {
                dictionary[1] = new("Direction", Direction);

            }
            if (Name.IsNotNullOrEmpty())
            {
                dictionary[2] = new("Name", Name);

            }

            ReadOnlySpan<KeyValuePair<string, string>> xx = new ReadOnlySpan<KeyValuePair<string, string>>(dictionary.Where(x => x.IsNotNullOrEmpty()).ToArray());
            CurrentContextAccessor.HttpContext?.Response.Cookies.Append(xx, cookieOptions);

            IHeaderDictionary headerDictionary = CurrentContextAccessor.HttpContext?.Response.Headers;
            foreach (var kvp in dictionary.Where(x => x.Key.IsNotNullOrEmpty()))
            {
                CurrentContextAccessor.HttpContext?.Response.Headers.Append(kvp.Key, kvp.Value);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }

}
