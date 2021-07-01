using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntDesign;
using AntDesign.TableModels;
using mbill_blazor_admin.Models.Base;
using mbill_blazor_admin.Models.BaseData.Input;
using mbill_blazor_admin.Models.BaseData.Output;
using mbill_blazor_admin.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace mbill_blazor_admin.Pages.BaseData.Asset
{
    public partial class Index
    {
        private AssetPageParams _page = new AssetPageParams();
        private bool _loading = false;
        private int _total = 0;
        private bool _editModalVisible = false;

        private SelectStringModel[] _types =
        {
            new SelectStringModel {Id = "", Name="全部", NotAvailable = false  },
            new SelectStringModel {Id = "deposit", Name="储蓄", NotAvailable = false  },
            new SelectStringModel {Id = "debt", Name="债务", NotAvailable = false  }
        };
        private IEnumerable<long> _selectedValues = new List<long>();
        private AssetModel[] _assetParents = { };
        private AssetModel[] _assets = { };
        private AssetModel _asset;

        [Inject] protected IBaseDataService BaseDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _assetParents = (await BaseDataService.GetAssetParents()).ToArray();
        }

        private async Task HandleOnSearch()
        {
            await GetAssets();
        }

        private async Task HandleOnReset()
        {
            _page = new AssetPageParams();
            await GetAssets();
        }
        private async Task HandleOnAddAsset()
        {
        }
        private void HandelOnEdit()
        {
            _editModalVisible = true;
        }

        private void HandelOnEditOk(MouseEventArgs e)
        {
            _editModalVisible = false;
        }

        private void HandleOnEditCancel(MouseEventArgs e)
        {
            _editModalVisible = false;
        }

        private void HandelOnDelete(long id)
        {
            throw new NotImplementedException();
        }

        private async Task HandelOnOnChange(QueryModel<AssetModel> model)
        {
            await GetAssets();
        }

        private void HandleOnSelectedItemsChanged(IEnumerable<AssetModel> models)
        {
            _page.ParentIds = string.Join(",", _selectedValues);
        }

        private void HandleOnTimeRangeChange(DateRangeChangedEventArgs args)
        {
            var date = args.Dates;
            _page.CreateStartTime = date[0]?.Date;
            _page.CreateEndTime = date[1]?.Date.AddDays(1).AddSeconds(-1);
        }

        private async Task GetAssets()
        {
            _loading = true;
            var assets = await BaseDataService.GetAssetPages(_page);
            _assets = assets.Items.ToArray();
            _total = (int)assets.Total;
            _loading = false;
        }
    }
}
