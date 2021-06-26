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
        private readonly AccountStorageJsService _accountStorageJsServic;

        public CoreService(CoreClient client, MessageService messageService, AccountStorageJsService accountStorageJsService)
        {
            _client = client;
            _messageService = messageService;
            _accountStorageJsServic = accountStorageJsService;
        }

        public async Task<bool> Login(LoginParams login)
        {
            var result = await _client.PostResultAsync<TokenModel>(CoreUrl.Login, login);
            if (result != null)
            {
                await _accountStorageJsServic.SetTokenAsync(result.AccessToken, result.RefreshToken);
                return true;
            }
            return false;
        }

        public async Task<UserModel> GetUserInfoByToken(bool isHintErr = true)
        {
            return await _client.GetAsync<UserModel>(CoreUrl.GetUserInfo, isHintErr);
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

        public async Task<RoleDetailModel> GetRoleDetail(long id)
        {
            return await _client.GetAsync<RoleDetailModel>(string.Format(CoreUrl.GetRoleDetail, id));
        }

        #endregion

        #region Permission

        public async Task<List<PermissionTreeModel>> GetPremisssionTrees()
        {
            return await _client.GetAsync<List<PermissionTreeModel>>(CoreUrl.GetPermissionTrees);
        }

        public async Task<PagedDto<LogModel>> GetLogs(LogPageParams pagingDto)
        {
            var url = CoreClient.GetSpliceUrlByObj(CoreUrl.GetLogs, pagingDto);
            return await _client.GetAsync<PagedDto<LogModel>>(url);
        }

        #endregion
    }
}
