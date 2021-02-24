using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mbill_blazor_admin.Models.Core
{
    public class PermissionModel
    {
        public string Name { get; set; }
        public string Module { get; set; }
        public string Router { get; set; }
    }
}
