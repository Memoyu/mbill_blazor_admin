using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mbill_blazor_admin.Models.Core
{
    public class RolePermissionModel
    {
        public long Id { get; set; }

        public long RoleId { get; set; }

        public long PermissionId { get; set; }
    }
}
