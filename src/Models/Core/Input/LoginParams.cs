using Mbill.Admin.Extensions.Validation;
using System.ComponentModel.DataAnnotations;

namespace Mbill.Admin.Models.Core.Input
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
