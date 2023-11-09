using AntDesign.TableModels;
using Mbill.Admin.Models.Base;
using Mbill.Admin.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Threading.Tasks;
using Mbill.Admin.Models.Core.Input;
using Mbill.Admin.Models.Core.Output;
using AntDesign;

namespace Mbill.Admin.Pages.Core.User
{
    public partial class Index
    {
        private SelectIntModel[] _isEnableStatus =
        {
            new SelectIntModel {Id = -1, Name="全部", NotAvailable = false  },
            new SelectIntModel {Id = 1, Name="启用", NotAvailable = false  },
            new SelectIntModel {Id = 0, Name="禁用", NotAvailable = false  }
        };
        private RoleModel[] _roleInfos = { };
        private UserModel[] _users = { };
        private bool _loading = false;
        private UserPageParams _page  = new UserPageParams();//new UserPageParams { Page = 0, Size = 10 };
        private int _total = 0;

        [Inject] protected ICoreService CoreService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            var roles = await CoreService.GetRoles();
            _roleInfos = roles.ToArray();
        }

        private async Task HandleOnSearch()
        {
            await GetUsers();
        }

        private async Task HandleOnReset()
        {
            _page = new UserPageParams();
            await GetUsers();
        }

        private async Task HandleOnAddUser()
        {
        }

        private async Task HandelOnOnChange(QueryModel<UserModel> queryModel)
        {
            Console.WriteLine("分页改变");
            await GetUsers();
        }

        private void HandleOnTimeRangeChange(DateRangeChangedEventArgs<DateTime?[]> args)
        {
            var date = args.Dates;
            _page.CreateStartTime = date[0]?.Date;
            _page.CreateEndTime = date[1]?.Date.AddDays(1).AddSeconds(-1);
        }

        private void HandelOnDelete(long id)
        {
            _users = _users.Where(x => x.Id != id).ToArray();
            _total = _users.Length;
        }

        private void HandelOnEdit()
        {
        }

        private async Task GetUsers()
        {
            _loading = true;
            var user = await CoreService.GetUserPages(_page);
            _users = user.Items.ToArray();
            _total = (int)user.Total;
            _loading = false;
        }
    }
}
