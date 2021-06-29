using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mbill_blazor_admin.Models.BaseData.Output
{
    public class CategoryModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long ParentId { get; set; }

        public string Type { get; set; }

        public decimal Budget { get; set; }

        public string IconUrl { get; set; }

        public string ParentName { get; set; }

        public string TypeName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

    }
}
