using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mbill_blazor_admin.Models.Core
{
    public class PermissionTreeModel
    {
        public long Id { get; set; }

        public string Rowkey { get; set; }

        public string Name { get; set; }

        public string Router { get; set; }

        public DateTime? CreateTime { get; set; }

        public PermissionTreeModel[] Children { get; set; }
    }
}
