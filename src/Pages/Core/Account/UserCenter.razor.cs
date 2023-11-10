using Mbill.Admin.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Mbill.Admin.Models.Core.Output;

namespace Mbill.Admin.Pages.Core.Account;

public partial class UserCenter
{
    private UserModel _currentUser = new UserModel();

    [Inject] protected ICoreService coreService { get; set; }
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        _currentUser = await coreService.GetUserInfoByToken();
    }
}
