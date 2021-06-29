using AntDesign;
using AntDesign.TableModels;
using mbill_blazor_admin.Models.Base;
using mbill_blazor_admin.Models.BaseData.Input;
using mbill_blazor_admin.Models.BaseData.Output;
using mbill_blazor_admin.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mbill_blazor_admin.Pages.BaseData.Category
{
    public partial class Index
    {
        private CategoryPageParams _page = new CategoryPageParams();
        private bool _loading = false;
        private int _total = 0;

        private SelectStringModel[] _types =
        {
            new SelectStringModel {Id = "", Name="全部", NotAvailable = false  },
            new SelectStringModel {Id = "expend", Name="支出", NotAvailable = false  },
            new SelectStringModel {Id = "income", Name="收入", NotAvailable = false  }
        };
        private IEnumerable<long> _selectedValues = new List<long>();
        private CategoryModel[] _categoryParents = { };
        private CategoryModel[] _categories = { };

        [Inject] protected IBaseDataService BaseDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _categoryParents = (await BaseDataService.GetCategoryParents()).ToArray();
        }

        private async Task HandleOnSearch()
        {
            await GetCategories();
        }

        private async Task HandleOnReset()
        {
            _page = new CategoryPageParams();
            await GetCategories();
        }

        private void Edit()
        {
            throw new NotImplementedException();
        }

        private void Delete(long id)
        {
            throw new NotImplementedException();
        }

        private async Task OnChange(QueryModel<CategoryModel> model)
        {
            await GetCategories();
        }

        private void HandleOnSelectedItemsChanged(IEnumerable<CategoryModel> models)
        {
            _page.ParentIds = string.Join(",", _selectedValues);
        }

        private void HandleOnTimeRangeChange(DateRangeChangedEventArgs args)
        {
            var date = args.Dates;
            _page.CreateStartTime = date[0]?.Date;
            _page.CreateEndTime = date[1]?.Date.AddDays(1).AddSeconds(-1);
        }

        private async Task GetCategories()
        {
            _loading = true;
            var categories = await BaseDataService.GetCategoryPages(_page);
            _categories = categories.Items.ToArray();
            _total = (int)categories.Total;
            _loading = false;
        }
    }
}
