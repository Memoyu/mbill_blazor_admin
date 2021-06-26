using mbill_blazor_admin.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using mbill_blazor_admin.Models.Core.Output;

namespace mbill_blazor_admin.Pages.Core.Account
{
    public partial class UserCenter
    {
        private UserModel _currentUser = new UserModel();

        [Inject] protected ICoreService coreService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _currentUser = await coreService.GetUserInfoByToken();
        }
    }
}
