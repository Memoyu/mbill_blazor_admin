using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mbill_blazor_admin.Models.Core.Output
{
    public class PermissionCardModel
    {
        public string Title { get; set; }
        public PermissionCheckModel[] PermissionChecks { get; set; }
    }

    public class PermissionCheckModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public bool Checked { get; set; }
    }
}
