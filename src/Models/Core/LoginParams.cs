using System.ComponentModel.DataAnnotations;

namespace mbill_blazor_admin.Models.Core
{
    public class LoginParams
    {
        [Required] public string UserName { get; set; }

        [Required] public string Password { get; set; }
    }
}
