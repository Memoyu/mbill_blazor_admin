using mbill_blazor_admin.Models.Core;
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

        public void HandleSubmit()
        {
            if (_loginModel.UserName == "admin" && _loginModel.Password == "ant.design")
            {
                NavigationManager.NavigateTo("/");
                return;
            }

            if (_loginModel.UserName == "user" && _loginModel.Password == "ant.design") NavigationManager.NavigateTo("/");
        }
    }
}
