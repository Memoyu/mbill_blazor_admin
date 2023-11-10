namespace Mbill.Admin.Models.Core.Output;

public class RoleModel
{
    public long BId { get; set; }
    public string Name { get; set; }
    public string Info { get; set; }
    public bool IsStatic { get; set; }
    public bool IsAdministrator { get; set; }
    public int Sort { get; set; }
}
