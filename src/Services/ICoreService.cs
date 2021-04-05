using mbill_blazor_admin.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
