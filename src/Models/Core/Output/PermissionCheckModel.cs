namespace Mbill.Admin.Models.Core.Output;

public class PermissionCardModel
{
    public string Title { get; set; }
    public PermissionCheckModel[] PermissionChecks { get; set; }
}

public class PermissionCheckModel
{
    public long BId { get; set; }
    public string Title { get; set; }
    public bool Checked { get; set; }
}
