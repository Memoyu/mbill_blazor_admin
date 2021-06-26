using System.Collections.Generic;

namespace mbill_blazor_admin.Models.Core
{
    public class RoleDetailModel
    {
        public List<RolePermissionModel> RolePermissions { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public bool IsStatic { get; set; }
        public int Sort { get; set; }
    }
}
