using Mbill.Admin.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Mbill.Admin.Models.Core.Output;

namespace Mbill.Admin.Pages.Core.Permission
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
