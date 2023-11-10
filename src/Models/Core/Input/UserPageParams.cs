using Mbill.Admin.Models.Base.Page;
using System;

namespace Mbill.Admin.Models.Core.Input;

public class UserPageParams : PagingDto
{
    public string Username { get; set; }

    public string Nickname { get; set; }

    public int IsEnable { get; set; } = -1;

    public long RoleBId { get; set; } = -1;

    public DateTime? CreateStartTime { get; set; }

    public DateTime? CreateEndTime { get; set; }
}
