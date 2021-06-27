namespace mbill_blazor_admin.Services.Base
{

    public static class CoreUrl
    {
        public const string Login = "account/login";
        public const string GetUserInfo = "account/user";
        public const string GetAllRoles = "admin/role/all";
        public const string GetRoleDetail = "admin/role/{0}"; 
        public const string EditRolePermission = "admin/permission/dispatch";
        public const string GetPermissionTrees = "admin/permission/tree";
        public const string GetLogs = "admin/log/pages";
    }

    public static class UserUrl
    {
        public const string GetPages = "admin/user/pages";
    }

    public static class BaseDataUrl
    {
        public const string GetAssetPages = "asset/pages";
        public const string GetAssetParents = "asset/parents";
    }
}
