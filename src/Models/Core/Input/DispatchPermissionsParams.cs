using System.Collections.Generic;

namespace Mbill.Admin.Models.Core.Input;

public class DispatchPermissionsParams
{
    public long RoleBId { get; set; }

    public List<long> PermissionBIds { get; set; }
}
