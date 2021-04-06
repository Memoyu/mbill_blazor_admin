using mbill_blazor_admin.Models.Core;
using mbill_blazor_admin.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace mbill_blazor_admin.Pages.Core.Account
{
    public partial class Login
    {
        bool loading = false;
        private LoginParams _loginModel = new LoginParams();
        [Inject] public NavigationManager _navigationManager { get; set; }
        [Inject] protected ICoreService _coreService { get; set; }

        public async void HandleSubmit()
        {
            loading = true;
            if (await _coreService.Login(_loginModel))
            {
                _navigationManager.NavigateTo("/", true);
            }
            loading = false;
            await InvokeAsync(StateHasChanged);

        }
    }
}
