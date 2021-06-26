using AntDesign;
using mbill_blazor_admin.Models.Core;
using mbill_blazor_admin.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mbill_blazor_admin.Pages.Core.Permission
{
    public partial class Index
    {
        private PermissionTreeModel[] _permissionTrees = { };

        [Inject] protected ICoreService CoreService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _permissionTrees = (await CoreService.GetPremisssionTrees()).ToArray();
        }
    }
}
