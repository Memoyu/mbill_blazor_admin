/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   命名空间 ：mbill_blazor_admin.Pages.Core.Role
*   文件名称 ：Index.cs
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2021-02-24 23:47:31
*   邮箱     ：mmy6076@outlook.com
*   功能描述 ：
***************************************************************************/
using AntDesign;
using AntDesign.TableModels;
using mbill_blazor_admin.Models.Core;
using mbill_blazor_admin.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mbill_blazor_admin.Pages.Core.Role
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
            _roles = (await CoreService.GetRoles()).ToArray();
            await base.OnInitializedAsync();
          
        }

        private void Delete(long id)
        {
            _roles = _roles.Where(x => x.Id != id).ToArray();
        }

        private void Edit(RoleModel role)
        {
            _visible = true;
            _role = role;
        }
        private void Permission(long id)
        {
            NavigationManager.NavigateTo($"/core/role/edit/{id}", true);
        }

        private void HandleOk(MouseEventArgs e)
        {
            Console.WriteLine(e);
            _visible = false;
        }

        private void HandleCancel(MouseEventArgs e)
        {
            Console.WriteLine(e);
            _visible = false;
        }
    }
}
