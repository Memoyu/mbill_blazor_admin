using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntDesign.Pro.Layout;
using Microsoft.AspNetCore.Components;
using AntDesign;
using mbill_blazor_admin.Core.Models;
using mbill_blazor_admin.Services.Impl;
using Microsoft.AspNetCore.Components.Authorization;
using mbill_blazor_admin.Models.Core;
using Microsoft.JSInterop;
using mbill_blazor_admin.Services.Base;
using Newtonsoft.Json;
using System;

namespace mbill_blazor_admin.Components
{
    public partial class RightContent 
    {
        private UserModel _currentUser = new UserModel
        {
            Username = "未登录"
        };
        private NoticeIconData[] _notifications = { };
        private NoticeIconData[] _messages = { };
        private NoticeIconData[] _events = { };
        private int _count = 0;

        [Inject] protected NavigationManager NavigationManager { get; set; }
        [Inject] protected MessageService MessageService { get; set; }
        [Inject] protected AuthenticationStateProvider authenticationService { get; set; }
        [Inject] protected IJSRuntime _jsRuntime { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var user = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", localStorageConst.UserInfo);
            Console.WriteLine("json" + user);
            //if (!string.IsNullOrWhiteSpace(user))
                _currentUser = JsonConvert.DeserializeObject<UserModel>(user);
            Console.WriteLine("json2" + _currentUser.Address);

            await base.OnInitializedAsync();
            SetClassMap();
        }

        

        protected void SetClassMap()
        {
            ClassMapper
                .Clear()
                .Add("right");
        }

        public async void HandleSelectUser(MenuItem item)
        {
            switch (item.Key)
            {
                case "center":
                    NavigationManager.NavigateTo("/account/center");
                    break;
                case "setting":
                    NavigationManager.NavigateTo("/account/settings");
                    break;
                case "logout":
                    var authComp = authenticationService as AuthenticationService;
                    await authComp.LogoutAsync();
                    NavigationManager.NavigateTo("/account/login");
                    break;
            }
        }

        public void HandleSelectLang(MenuItem item)
        {
        }

        public async Task HandleClear(string key)
        {
            switch (key)
            {
                case "notification":
                    _notifications = new NoticeIconData[] { };
                    break;
                case "message":
                    _messages = new NoticeIconData[] { };
                    break;
                case "event":
                    _events = new NoticeIconData[] { };
                    break;
            }
            await MessageService.Success($"清空了{key}");
        }

        public async Task HandleViewMore(string key)
        {
            await MessageService.Info("Click on view more");
        }
    }
}