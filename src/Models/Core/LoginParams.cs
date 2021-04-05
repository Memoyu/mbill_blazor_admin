using mbill_blazor_admin.Extensions.Validation;
using System.ComponentModel.DataAnnotations;

namespace mbill_blazor_admin.Models.Core
{
    public class LoginParams
    {
        [CoreRequired(Msg = "用户名不能为空！")]
        public string Username { get; set; }

        [CoreRequired(Msg = "密码不能为空！")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
