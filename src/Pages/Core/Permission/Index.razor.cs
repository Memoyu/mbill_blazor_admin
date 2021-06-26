using mbill_blazor_admin.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using mbill_blazor_admin.Models.Core.Output;

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
