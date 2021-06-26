using AntDesign;
using AntDesign.TableModels;
using mbill_blazor_admin.Models.Base;
using mbill_blazor_admin.Models.Core;
using mbill_blazor_admin.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mbill_blazor_admin.Pages.Core.User
{
    public partial class Index
    {
        private SelectModel[] _isEnableStatus =
        {
            new SelectModel {Id = -1, Name="全部", NotAvailable = false  },
            new SelectModel {Id = 1, Name="启用", NotAvailable = false  },
            new SelectModel {Id = 0, Name="禁用", NotAvailable = false  }
        };
        private RoleModel[] _roleInfos = { };
        private UserModel[] _users = { };
        private bool _loading = false;
        private UserPageParams _page  = new UserPageParams();//new UserPageParams { Page = 0, Size = 10 };
        private int _total = 0;
        [Inject] protected ICoreService CoreService { get; set; }

        protected override async Task OnInitializedAsync()
        {

            //var roles = await CoreService.GetRoles();
            //roles.Insert(0, new RoleModel { Id = -1, Name = "全部" });
            //_roleInfos = roles.ToArray();
            await base.OnInitializedAsync();

        }

        private void IsEnableHandleChange(SelectModel value)
        {

        }

        private async Task OnChange(QueryModel<UserModel> queryModel)
        {
            Console.WriteLine("分页改变");
            await GetUsers();
        }

        private void Delete(long id)
        {
            _users = _users.Where(x => x.Id != id).ToArray();
            _total = _users.Length;
        }

        private void Edit()
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
        private void EnterInquireRole()
        {
            Console.WriteLine("查询");
        }
    }
}
