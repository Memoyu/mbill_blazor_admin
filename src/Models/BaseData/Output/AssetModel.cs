using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mbill.Admin.Models.BaseData.Output
{
    public class AssetModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long ParentId { get; set; }

        public string Type { get; set; }

        public decimal Amount { get; set; }

        public string IconUrl { get; set; }

        public string ParentName { get; set; }

        public string TypeName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
