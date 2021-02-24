using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mbill_blazor_admin.Models.Core
{
    public class RoleModel
    {
        public List<PermissionModel> Permissions { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public bool IsStatic { get; set; }
    }
}
