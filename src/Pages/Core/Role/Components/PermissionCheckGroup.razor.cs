using System.Linq;
using AntDesign;
using Mbill.Admin.Models.Core.Output;
using Microsoft.AspNetCore.Components;

namespace Mbill.Admin.Pages.Core.Role;


public partial class PermissionCheckGroup
{
    [Parameter] public PermissionCheckModel[] Checks { get; set; }
    [Parameter] public string Title { get; set; }

    bool indeterminate => Checks.Count(o => o.Checked) > 0 && Checks.Count(o => o.Checked) < Checks.Count();

    bool checkAll => Checks.All(o => o.Checked);

    void CheckAllChanged()
    {
        bool allChecked = checkAll;
        Checks.ForEach(o => o.Checked = !allChecked);
    }

    void OnChanged()
    {

    }
}
