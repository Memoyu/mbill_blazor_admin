using AntDesign;
using mbill_blazor_admin.Models.Base.Page;
using mbill_blazor_admin.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using mbill_blazor_admin.Models.Core.Input;
using mbill_blazor_admin.Models.Core.Output;

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

        public async Task<bool> EditRolePermission(DispatchPermissionsParams model)
        {
            var result = await _client.PostAsync(CoreUrl.EditRolePermission, model);
            if (result)
                await _messageService.Success("修改权限成功");
            else
                await _messageService.Error("修改权限失败");
            return result;
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
