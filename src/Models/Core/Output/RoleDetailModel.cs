using System.Collections.Generic;

namespace Mbill.Admin.Models.Core.Output
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
