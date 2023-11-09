using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mbill.Admin.Models.Base
{
    public class SelectIntModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool NotAvailable { get; set; }
    }

    public class SelectStringModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool NotAvailable { get; set; }
    }
}
