using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using AntDesign;
using mbill_blazor_admin.Services.Impl;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using mbill_blazor_admin.Services;
using AntDesign.ProLayout;
using mbill_blazor_admin.Models.Core.Output;

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
        [Inject] protected ICoreService coreService { get; set; }
        [Inject] protected IJSRuntime _jsRuntime { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            SetClassMap();
            _currentUser = await coreService.GetUserInfoByToken() ?? new UserModel { Username = "未登录" };
        }

        //protected override async Task OnAfterRenderAsync(bool firstRender)
        //{
        //    if (firstRender)
        //    {
        //        var user = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", localStorageConst.UserInfo);
        //        Console.WriteLine("顶栏加载");
        //        if (!string.IsNullOrWhiteSpace(user))
        //            _currentUser = JsonConvert.DeserializeObject<UserModel>(user);
        //        await InvokeAsync(StateHasChanged);
        //    }
        //    await base.OnAfterRenderAsync(firstRender);
        //}

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