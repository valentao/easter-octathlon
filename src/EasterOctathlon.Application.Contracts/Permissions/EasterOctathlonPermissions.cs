namespace EasterOctathlon.Permissions;

public static class EasterOctathlonPermissions
{
    public const string GroupName = "EasterOctathlon";

    public static class Participants
    {
        public const string Default = GroupName + ".Participants";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}
