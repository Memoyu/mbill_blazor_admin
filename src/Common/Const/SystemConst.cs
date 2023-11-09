using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mbill.Admin.Common.Const
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

    /// <summary>
    /// 选取器
    /// </summary>
    public class Switcher
    {
        public static string CategoryType(string type) => type switch
        {
            "expend" => "支出",
            "income" => "收入",
            _ => "",
        };

        public static string AssetType(string type) => type switch
        {
            "deposit" => "储蓄",
            "debt" => "债务",
            _ => "",
        };
    }
}
