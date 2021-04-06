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
        private List<SelectModel> _isEnableStatus = new List<SelectModel>
        {
            new SelectModel {Id = -1, Name="全部", NotAvailable = false  },
            new SelectModel {Id = 1, Name="启用", NotAvailable = false  },
            new SelectModel {Id = 0, Name="禁用", NotAvailable = false  }
        };
        private int? _selectedValue = 1;
        private bool _loading = false;
        private ITable table;
        private UserModel[] _users = { };
        private IEnumerable<UserModel> _selectedRows;
        private UserPageParams page = new UserPageParams { Page = 0, Size = 10 };
        private int _total = 0;
        [Inject] protected ICoreService coreService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _loading = true;
            var user = await coreService.GetUserPages(page);
            _users = user.Items.ToArray();
            _total = (int)user.Total;
            _loading = false;

        }

        private void IsEnableHandleChange(SelectModel value)
        {

        }

        private async Task onChange(QueryModel<UserModel> queryModel)
        {
            page.Page = queryModel.PageIndex;
            page.Size = queryModel.PageSize;
            var user = await coreService.GetUserPages(page);
            _users = user.Items.ToArray();
            _total = (int)user.Total;
        }

        public void RemoveSelection(long id)
        {
            var selected = _selectedRows.Where(x => x.Id != id);
            _selectedRows = selected;

            //table.SetSelection(selected.Select(x => x.Id.ToString()).ToArray());
        }

        private void Delete(long id)
        {
            _users = _users.Where(x => x.Id != id).ToArray();
            _total = _users.Length;
        }

        private void Edit()
        {
        }

    }
}
