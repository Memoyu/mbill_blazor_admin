using Mbill.Admin.Services.Base;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mbill.Admin.Services.Impl
{
    public class AccountStorageJsService
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly NavigationManager _navigationManager;
        public AccountStorageJsService(IJSRuntime jsRuntime, NavigationManager navigationManager)
        {
            _jsRuntime = jsRuntime;
            _navigationManager = navigationManager;
        }
        /// <summary>
        /// 获取localStorage Token
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetTokenAsync()
        {
            return await _jsRuntime.InvokeAsync<string>("localStorage.getItem", localStorageConst.Token);
        }

        /// <summary>
        /// 写入Token到localStorage
        /// </summary>
        /// <returns></returns>
        public async Task SetTokenAsync(string token, string refreshToken)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", localStorageConst.Token, token);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", localStorageConst.RefreshToken, refreshToken);
        }

        /// <summary>
        /// 移除localStorage中的Token
        /// </summary>
        /// <returns></returns>
        public async Task RemoveTokenAsync()
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", localStorageConst.Token);
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", localStorageConst.RefreshToken);
            _navigationManager.NavigateTo("/account/login");
        }
    }
}
