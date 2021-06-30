using mbill_blazor_admin.Models.Base.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mbill_blazor_admin.Models.Core.Input
{
    public class UserPageParams : PagingDto
    {
        public string Username { get; set; }

        public string Nickname { get; set; }

        public int IsEnable { get; set; } = -1;

        public long RoleId { get; set; } = -1;

        public DateTime? CreateStartTime { get; set; }

        public DateTime? CreateEndTime { get; set; }
    }
}
