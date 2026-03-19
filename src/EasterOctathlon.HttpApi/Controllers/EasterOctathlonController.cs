using EasterOctathlon.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace EasterOctathlon.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class EasterOctathlonController : AbpControllerBase
{
    protected EasterOctathlonController()
    {
        LocalizationResource = typeof(EasterOctathlonResource);
    }
}
