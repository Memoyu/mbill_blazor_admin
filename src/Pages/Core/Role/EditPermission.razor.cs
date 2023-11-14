using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntDesign;
using Mbill.Admin.Models.Core.Input;
using Mbill.Admin.Models.Core.Output;
using Mbill.Admin.Services;
using Mbill.Admin.Services.Impl;
using Microsoft.AspNetCore.Components;

namespace Mbill.Admin.Pages.Core.Role;

public partial class EditPermission
{
    [Parameter] public long BId { get; set; }

    private PermissionCardModel[] _permissionCards = { };

    private PermissionTreeModel[] _permissionTrees = { };
    [Inject] protected ICoreService CoreService { get; set; }

    [Inject] public CommonJsService CommonJsService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _permissionTrees = (await CoreService.GetPremisssionTrees()).ToArray();
        var roleDetail = await CoreService.GetRoleDetail(BId);
        _permissionCards = _permissionTrees.Select(pt => new PermissionCardModel
        {
            Title = pt.Name,
            PermissionChecks = pt.Children.Select(ptc => new PermissionCheckModel
            {
                BId = ptc.BId,
                Title = ptc.Name,
                Checked = roleDetail.RolePermissions.Any(rp => rp.PermissionBId == ptc.BId)
            }).ToArray()
        }).ToArray();
        await base.OnInitializedAsync();
    }

    private async Task Save()
    {
        var checkedPermissionIds = new List<long>();
        _permissionCards.ForEach(pc =>
        {
            foreach (var item in pc.PermissionChecks)
                if (item.Checked)
                    checkedPermissionIds.Add(item.BId);
        });

        var model = new DispatchPermissionsParams
        {
            RoleBId = BId,
            PermissionBIds = checkedPermissionIds
        };

        var res = await CoreService.EditRolePermission(model);
    }

    private async Task GoBack()
    {
    }
}
