/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   命名空间 ：Mbill.Admin.Pages.Core.Role
*   文件名称 ：Index.cs
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2021-02-24 23:47:31
*   邮箱     ：mmy6076@outlook.com
*   功能描述 ：
***************************************************************************/
using AntDesign;
using Mbill.Admin.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mbill.Admin.Common.Const;
using Mbill.Admin.Models.Core.Output;

namespace Mbill.Admin.Pages.Core.Role
{
    public partial class Index
    {
        private ITable table;
        private RoleModel[] _roles = { };
        private IEnumerable<RoleModel> _selectedRows;
        private bool _visible = false;
        private RoleModel _role;
        [Inject] protected ICoreService CoreService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            var roles = (await CoreService.GetRoles()).Select(r =>
            {
                if (r.Id == StaticRole.Administrator)
                    r.IsAdministrator = true;
                return r;
            }).ToArray();
            _roles = roles;

        }

        private async Task HandleOnAddRole()
        {
        }

        private void HandelOnDelete(long id)
        {
            _roles = _roles.Where(x => x.Id != id).ToArray();
        }

        private void HandelOnEdit(RoleModel role)
        {
            _visible = true;
            _role = role;
        }
        private void HandelOnEditPermission(long id)
        {
            NavigationManager.NavigateTo($"/core/role/edit/{id}", true);
        }

        private void HandelOnOk(MouseEventArgs e)
        {
            Console.WriteLine(e);
            _visible = false;
        }

        private void HandleOnCancel(MouseEventArgs e)
        {
            Console.WriteLine(e);
            _visible = false;
        }
    }
}
