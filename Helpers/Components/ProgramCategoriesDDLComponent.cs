using Microsoft.AspNetCore.Mvc;

using Qimmah.Core.Activities;

namespace Qimmah.Helpers.Components;

public class ProgramCategoriesDDLComponent : ViewComponent
{
    private readonly IProgramService? programService;

    public ProgramCategoriesDDLComponent(IProgramService? programService)
    {
        this.programService = programService;
    }

    public async Task<IViewComponentResult> InvokeAsync(string OnChangeFunction, string permanentLabel = null)
    {
        var categories = await programService.GetCategoriesAsync();
        return View("_CategoriesDDL", (categories, OnChangeFunction));
    }
}
