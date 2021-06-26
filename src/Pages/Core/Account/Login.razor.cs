using mbill_blazor_admin.Services;
using Microsoft.AspNetCore.Components;
using mbill_blazor_admin.Models.Core.Input;

namespace mbill_blazor_admin.Pages.Core.Account
{
    public partial class Login
    {
        bool loading = false;
        private LoginParams _loginModel = new LoginParams {Username = "administrator", Password = "123456"};
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] protected ICoreService CoreService { get; set; }

        public async void HandleSubmit()
        {
            loading = true;
            if (await CoreService.Login(_loginModel))
            {
                NavigationManager.NavigateTo("/", true);
            }
            loading = false;
            await InvokeAsync(StateHasChanged);

        }
    }
}
