using EasterOctathlon.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EasterOctathlon.Web.Pages;

public abstract class EasterOctathlonPageModel : AbpPageModel
{
    protected EasterOctathlonPageModel()
    {
        LocalizationResourceType = typeof(EasterOctathlonResource);
    }
}
