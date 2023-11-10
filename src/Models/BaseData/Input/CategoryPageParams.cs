using Mbill.Admin.Models.Base.Page;
using System;

namespace Mbill.Admin.Models.BaseData.Input;

public class CategoryPageParams : PagingDto
{
    public string CategoryName { get; set; }

    public string ParentBIds { get; set; }

    public string Type { get; set; } = "";

    public DateTime? CreateStartTime { get; set; }

    public DateTime? CreateEndTime { get; set; }
}
