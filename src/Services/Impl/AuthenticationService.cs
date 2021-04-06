using System;
using System.Security.Claims;
using System.Threading.Tasks;
using mbill_blazor_admin.Models.Core;
using mbill_blazor_admin.Services.Base;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace mbill_blazor_admin.Services.Impl
{
    public class AuthenticationService : AuthenticationStateProvider
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly NavigationManager _navigationManager;
        private readonly ICoreService _coreService;
        private readonly AccountStorageService _accountStorageServic;

        public AuthenticationService(IJSRuntime jsRuntime, NavigationManager navigationManager, AccountStorageService accountStorageService, ICoreService coreService)
        {
            _jsRuntime = jsRuntime;
            _navigationManager = navigationManager;
            _coreService = coreService;
            _accountStorageServic = accountStorageService;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _accountStorageServic.GetTokenAsync();
            if (string.IsNullOrEmpty(token)) return GetUnAuthState();

            // 获取用户信息
            var user = await _coreService.GetUserInfoByToken(false);
            if (user == null) GetUnAuthState();
            Console.WriteLine("授权写入");
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", localStorageConst.UserInfo, JsonConvert.SerializeObject(user));

            var identity = new ClaimsIdentity(new[]
              {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("avatar", user.AvatarUrl),
                }, "memoyu.mbill.blazor auth");
            var principal = new ClaimsPrincipal(identity);
            return new AuthenticationState(principal);
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public async Task LogoutAsync()
        {
            await _accountStorageServic.RemoveTokenAsync();
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", localStorageConst.UserInfo);
            NotifyAuthenticationStateChanged(Task.FromResult(GetUnAuthState(false)));
        }

        private AuthenticationState GetUnAuthState(bool isJump = true)
        {
            if (isJump)
                _navigationManager.NavigateTo("/account/login");

            var principal = new ClaimsPrincipal(new ClaimsIdentity());
            return new AuthenticationState(principal);
        }
    }
}
