using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mbill.Admin.Models.Core.Input
{
    public class DispatchPermissionsParams
    {
        public long RoleId { get; set; }

        public List<long> PermissionIds { get; set; }
    }
}
