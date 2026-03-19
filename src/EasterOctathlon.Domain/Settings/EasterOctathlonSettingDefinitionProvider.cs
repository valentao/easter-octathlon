using Volo.Abp.Settings;

namespace EasterOctathlon.Settings;

public class EasterOctathlonSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(EasterOctathlonSettings.MySetting1));
    }
}
