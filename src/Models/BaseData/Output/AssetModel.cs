using System;

namespace Mbill.Admin.Models.BaseData.Output;

public class AssetModel
{
    public long BId { get; set; }

    public string Name { get; set; }

    public long ParentBId { get; set; }

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
