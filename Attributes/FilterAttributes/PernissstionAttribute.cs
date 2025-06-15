using Microsoft.AspNetCore.Mvc.Filters;



namespace Qimmah.Attributes.FilterAttributes
{
    //public class ViewPermissionInitializerAttribute : Attribute, IAsyncActionFilter
    //{
    //    public EnumPrivilege _viewID { get; }
    //    public List<EnumPrivilege> _lstView { get; }
    //    public bool IsSingle { get; set; }

    //    public ViewPermissionInitializerAttribute(EnumPrivilege ViewID)
    //    {
    //        _viewID = ViewID;
    //        IsSingle = true;
    //    }

    //    public ViewPermissionInitializerAttribute(params EnumPrivilege[] lstviews)
    //    {
    //        _lstView = lstviews.ToList();
    //        IsSingle = false;
    //    }

    //    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    //    {
    //        if (context.Controller is AuthorizedController controller)
    //        {
    //            if (_lstView.IsNotNullOrEmpty())
    //            {
    //                controller._lstpermissions = __CurrentUser.Privileges.Where(x => x.Value == true && _lstView.Contains(x.Key)).Select(x => x.Key).ToList();
    //            }
    //            else if (_viewID.IsNotNullOrEmpty())
    //            {
    //                controller._permissions = __CurrentUser.Privileges.FirstOrDefault(x => x.Value == true && x.Key == _viewID).Key;
    //            }
    //            await next();
    //        }
    //    }
    //}
}                                                          