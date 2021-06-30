using mbill_blazor_admin.Models.Base.Page;
using System;

namespace mbill_blazor_admin.Models.Core.Input
{
    public class LogPageParams : PagingDto
    {
        public string Method { get; set; } = "";

        public string Username { get; set; }

        public string UserId { get; set; } = "";

        public string StatusCode { get; set; } = "";

        public DateTime? CreateStartTime { get; set; }

        public DateTime? CreateEndTime { get; set; }
    }
}
