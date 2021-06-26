using mbill_blazor_admin.Models.Base.Page;
using mbill_blazor_admin.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mbill_blazor_admin.Models.Core.Input;
using mbill_blazor_admin.Models.Core.Output;

namespace mbill_blazor_admin.Services
{
    public interface ICoreService
    {
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="login">用户名/密码</param>
        /// <returns></returns>
        Task<bool> Login(LoginParams login);

        /// <summary>
        /// 获取用户信息(By Token)
        /// </summary>
        /// <returns></returns>
        Task<UserModel> GetUserInfoByToken(bool isHintErr = true);

        /// <summary>
        /// 获取用户分页信息
        /// </summary>
        /// <param name="pagingDto"></param>
        /// <returns></returns>
        Task<PagedDto<UserModel>> GetUserPages(UserPageParams pagingDto);

        /// <summary>
        /// 获取全部角色信息
        /// </summary>
        /// <returns></returns>
        Task<List<RoleModel>> GetRoles();

        /// <summary>
        /// 获取角色详情
        /// </summary>
        /// <param name="id">角色</param>
        /// <returns></returns>
        Task<RoleDetailModel> GetRoleDetail(long id);

        /// <summary>
        /// 修改角色权限
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        Task<bool> EditRolePermission(DispatchPermissionsParams model);

        /// <summary>
        /// 获取权限树形信息
        /// </summary>
        /// <returns></returns>
        Task<List<PermissionTreeModel>> GetPremisssionTrees();

        /// <summary>
        /// 获取日志记录
        /// </summary>
        /// <param name="pagingDto"></param>
        /// <returns></returns>
        Task<PagedDto<LogModel>> GetLogs(LogPageParams pagingDto);
    }
}
