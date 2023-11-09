using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mbill.Admin.Models.Core.Output
{
    public class RoleModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public bool IsStatic { get; set; }
        public bool IsAdministrator { get; set; }
        public int Sort { get; set; }
    }
}
