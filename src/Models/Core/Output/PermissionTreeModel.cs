using System;

namespace Mbill.Admin.Models.Core.Output;

public class PermissionTreeModel
{
    public long BId { get; set; }

    public string Rowkey { get; set; }

    public string Name { get; set; }

    public string Router { get; set; }

    public DateTime? CreateTime { get; set; }

    public PermissionTreeModel[] Children { get; set; }
}
