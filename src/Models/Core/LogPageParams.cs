using mbill_blazor_admin.Models.Base.Page;
using System;

namespace mbill_blazor_admin.Models.Core
{
    public class LogPageParams : PagingDto
    {
        public string Method { get; set; }
        public string Username { get; set; }
        public long UserId { get; set; }
        public int StatusCode { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
