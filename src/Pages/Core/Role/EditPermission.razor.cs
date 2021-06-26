using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntDesign;
using mbill_blazor_admin.Models.Core.Input;
using mbill_blazor_admin.Models.Core.Output;
using mbill_blazor_admin.Services;
using mbill_blazor_admin.Services.Impl;
using Microsoft.AspNetCore.Components;

namespace mbill_blazor_admin.Pages.Core.Role
{
    public partial class EditPermission
    {
        [Parameter] public long Id { get; set; }

        private PermissionCardModel[] _permissionCards = { };

        private PermissionTreeModel[] _permissionTrees = { };
        [Inject] protected ICoreService CoreService { get; set; }

        [Inject] public CommonJsService CommonJsService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _permissionTrees = (await CoreService.GetPremisssionTrees()).ToArray();
            var roleDetail = await CoreService.GetRoleDetail(Id);
            _permissionCards = _permissionTrees.Select(pt => new PermissionCardModel
            {
                Title = pt.Name,
                PermissionChecks = pt.Children.Select(ptc => new PermissionCheckModel
                {
                    Id = ptc.Id,
                    Title = ptc.Name,
                    Checked = roleDetail.RolePermissions.Any(rp => rp.PermissionId == ptc.Id)
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
                        checkedPermissionIds.Add(item.Id);
            });

            var model = new DispatchPermissionsParams
            {
                RoleId = Id,
                PermissionIds = checkedPermissionIds
            };

            var res = await CoreService.EditRolePermission(model);
        }

        private async Task GoBack()
        {
        }
    }
}
