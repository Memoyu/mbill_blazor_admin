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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mbill_blazor_admin.Pages.Core.Role
{
    public partial class Index
    {
        private ITable table;
        private RoleModel[] _roles =
        {
           
            new RoleModel
            {
                Id=1,
                Name = "Administrator",
                Info="超级管理员",
                Sort=0,
                IsStatic = false
            },
            new RoleModel
            {
                Id=2,
                Name = "Admin",
                Info="管理员",
                Sort=0,
                IsStatic = true
            }, 
            new RoleModel
            {
                Id=3,
                Name = "User",
                Info="普通用户",
                Sort=0,
                IsStatic = false
            }
        };
        private IEnumerable<RoleModel> _selectedRows;
        private int _pageIndex = 1;
        private int _pageSize = 10;
        private int _total = 0;


        private async Task onChange(QueryModel<RoleModel> queryModel)
        {
            //forecasts = await GetForecastAsync(queryModel.PageIndex, queryModel.PageSize);
            _pageIndex = queryModel.PageIndex;
            _pageSize = queryModel.PageSize;
            _total = 50;
        }

        public void RemoveSelection(long id)
        {
            var selected = _selectedRows.Where(x => x.Id != id);
            _selectedRows = selected;

            //table.SetSelection(selected.Select(x => x.Id.ToString()).ToArray());
        }

        private void Delete(long id)
        {
            _roles = _roles.Where(x => x.Id != id).ToArray();
            _total = _roles.Length;
        }

        private void Edit()
        {
        }
        private void Permission(long id)
        {
        }
    }
}
