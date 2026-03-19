using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;
using Microsoft.Extensions.Localization;
using EasterOctathlon.Localization;

namespace EasterOctathlon.Web;

[Dependency(ReplaceServices = true)]
public class EasterOctathlonBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<EasterOctathlonResource> _localizer;

    public EasterOctathlonBrandingProvider(IStringLocalizer<EasterOctathlonResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
