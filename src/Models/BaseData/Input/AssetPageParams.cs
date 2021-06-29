using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mbill_blazor_admin.Models.Base.Page;

namespace mbill_blazor_admin.Models.BaseData.Input
{
    public class AssetPageParams : PagingDto
    {
        public string AssetName { get; set; }

        public string ParentIds { get; set; }

        public string Type { get; set; } = "";

        public DateTime? CreateStartTime { get; set; }

        public DateTime? CreateEndTime { get; set; }
    }
}
