using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mbill.Admin.Models.Core.Output
{
    public class RolePermissionModel
    {
        public long Id { get; set; }

        public long RoleId { get; set; }

        public long PermissionId { get; set; }
    }
}
