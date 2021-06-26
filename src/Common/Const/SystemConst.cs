using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mbill_blazor_admin.Common.Const
{
    /// <summary>
    /// 默认角色
    /// </summary>
    public static class StaticRole
    {
        /// <summary>
        /// 超级管理员
        /// </summary>
        public static int Administrator = 1;
        /// <summary>
        /// 普通管理员
        /// </summary>
        public static int Admin = 2;
        /// <summary>
        /// 用户
        /// </summary>
        public static int User = 3;
    }
}
