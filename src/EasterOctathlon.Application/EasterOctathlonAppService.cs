using EasterOctathlon.Localization;
using Volo.Abp.Application.Services;

namespace EasterOctathlon;

/* Inherit your application services from this class.
 */
public abstract class EasterOctathlonAppService : ApplicationService
{
    protected EasterOctathlonAppService()
    {
        LocalizationResource = typeof(EasterOctathlonResource);
    }
}
