using EasterOctathlon.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace EasterOctathlon.Permissions;

public class EasterOctathlonPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(EasterOctathlonPermissions.GroupName);
        var participantsPermission = myGroup.AddPermission(
            EasterOctathlonPermissions.Participants.Default,
            L("Permission:Participants"));

        participantsPermission.AddChild(
            EasterOctathlonPermissions.Participants.Create,
            L("Permission:Participants.Create"));

        participantsPermission.AddChild(
            EasterOctathlonPermissions.Participants.Edit,
            L("Permission:Participants.Edit"));

        participantsPermission.AddChild(
            EasterOctathlonPermissions.Participants.Delete,
            L("Permission:Participants.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<EasterOctathlonResource>(name);
    }
}
