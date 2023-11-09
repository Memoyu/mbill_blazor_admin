using Mbill.Admin.Services;
using Microsoft.AspNetCore.Components;
using Mbill.Admin.Models.Core.Input;

namespace Mbill.Admin.Pages.Core.Account
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
