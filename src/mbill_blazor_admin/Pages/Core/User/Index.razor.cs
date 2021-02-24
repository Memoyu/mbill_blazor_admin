using AntDesign;
using AntDesign.TableModels;
using mbill_blazor_admin.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mbill_blazor_admin.Pages.Core.User
{
    public partial class Index
    {
        private ITable table;
        private UserModle[] _users =
        {
            new UserModle
            {
                Id=1,
                Username = "蒙明宇",
                Nickname="Memoyu",
                Gender="男",
                Email = "mmy6076@outlook.com",
                Phone = "1887861343",
                Address="白云区",
                IsEnable= true
            },
            new UserModle
            {
                Id=2,
                Username = "Administrator",
                Nickname="Administrator",
                Gender="男",
                Email = "mmy0925@outlook.com",
                Phone = "1887861343",
                Address="白云区",
                IsEnable= true
            },
            new UserModle
            {
                Id=3,
                Username = "Admin",
                Nickname="Admin",
                Gender="男",
                Email = "mmy6076@outlook.com",
                Phone = "1887861343",
                Address="白云区",
                IsEnable= true
            }
        };
        private IEnumerable<UserModle> _selectedRows;
        private int _pageIndex = 1;
        private int _pageSize = 10;
        private int _total = 0;


        private async Task onChange(QueryModel<UserModle> queryModel)
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
            _users = _users.Where(x => x.Id != id).ToArray();
            _total = _users.Length;
        }

        private void Edit()
        {
        }
    }
}
