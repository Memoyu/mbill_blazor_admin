using AntDesign;
using mbill_blazor_admin.Models.Base;
using mbill_blazor_admin.Models.Base.Page;
using mbill_blazor_admin.Models.Core;
using mbill_blazor_admin.Services.Base;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mbill_blazor_admin.Services.Impl
{
    public class CoreService : ICoreService
    {
        private readonly CoreClient _client;
        private readonly MessageService _messageService;
        private readonly AccountStorageService _accountStorageServic;

        public CoreService(CoreClient client, MessageService messageService, AccountStorageService accountStorageService)
        {
            _client = client;
            _messageService = messageService;
            _accountStorageServic = accountStorageService;
        }

        public async Task<bool> Login(LoginParams login)
        {
            var result = await _client.PostResultAsync<TokenModel>(CoreUrl.Login, login);
            if (result != null)
            {
                await _accountStorageServic.SetTokenAsync(result.AccessToken, result.RefreshToken);
                return true;
            }
            return false;
        }

        public async Task<UserModel> GetUserInfoByToken(bool isHintErr = true)
        {
            return await _client.GetAsync<UserModel>(UserUrl.GetInfo, isHintErr);
        }

        public async Task<PagedDto<UserModel>> GetUserPages(UserPageParams pagingDto)
        {
            var url = CoreClient.GetSpliceUrlByObj(UserUrl.GetPages, pagingDto);
            return await _client.GetAsync<PagedDto<UserModel>>(url);
        }

        #region Roles

        public async Task<List<RoleModel>> GetRoles()
        {
            return await _client.GetAsync<List<RoleModel>>(CoreUrl.GetAllRoles);
        }

        #endregion
    }
}
