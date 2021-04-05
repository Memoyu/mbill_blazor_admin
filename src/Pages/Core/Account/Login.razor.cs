using mbill_blazor_admin.Models.Core;
using mbill_blazor_admin.Services;
using mbill_blazor_admin.Services.Base;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mbill_blazor_admin.Pages.Core.Account
{
    public partial class Login
    {
        private readonly LoginParams _loginModel = new LoginParams();
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] protected ICoreService _coreService { get; set; }

        public async void HandleSubmit()
        {
            if (await _coreService.Login(_loginModel))
            {
                NavigationManager.NavigateTo("/", true);
                return;
            }
        }
    }
}
