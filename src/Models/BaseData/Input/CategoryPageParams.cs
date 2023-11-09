using Mbill.Admin.Models.Base.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mbill.Admin.Models.BaseData.Input
{
    public class CategoryPageParams : PagingDto
    {
        public string CategoryName { get; set; }

        public string ParentIds { get; set; }

        public string Type { get; set; } = "";

        public DateTime? CreateStartTime { get; set; }

        public DateTime? CreateEndTime { get; set; }
    }
}
