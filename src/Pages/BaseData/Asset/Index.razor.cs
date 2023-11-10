using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntDesign;
using AntDesign.TableModels;
using Mbill.Admin.Models.Base;
using Mbill.Admin.Models.BaseData.Input;
using Mbill.Admin.Models.BaseData.Output;
using Mbill.Admin.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Mbill.Admin.Pages.BaseData.Asset;

public partial class Index
{
    private AssetPageParams _page = new AssetPageParams();
    private bool _loading = false;
    private bool _uploadLoading = false;
    private int _total = 0;
    private bool _editModalVisible = false;

    private SelectStringModel[] _types =
    {
        new SelectStringModel {Id = "deposit", Name="储蓄", NotAvailable = false  },
        new SelectStringModel {Id = "debt", Name="债务", NotAvailable = false  }
    };
    private IEnumerable<long> _selectedValues = new List<long>();
    private AssetModel[] _assetParents = { };
    private AssetModel[] _assets = { };
    private AssetModel _asset;

    [Inject] protected IBaseDataService BaseDataService { get; set; }
    [Inject] protected MessageService MessageService { get; set; }

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

    private void HandelOnEdit(AssetModel model)
    {
        _asset = model;
        _editModalVisible = true;
    }

    bool BeforeUpload(UploadFileItem file)
    {
        var isJpgOrPng = file.Type == "image/jpeg" || file.Type == "image/png";
        if (!isJpgOrPng)
        {
            MessageService.Error("You can only upload JPG/PNG file!");
        }
        var isLt2M = file.Size / 1024 / 1024 < 2;
        if (!isLt2M)
        {
            MessageService.Error("Image must smaller than 2MB!");
        }
        return isJpgOrPng && isLt2M;
    }

    void HandleChange(UploadInfo fileinfo)
    {
        _uploadLoading = fileinfo.File.State == UploadState.Uploading;

        if (fileinfo.File.State == UploadState.Success)
        {
            _asset.IconUrl = fileinfo.File.ObjectURL;
        }
        InvokeAsync(StateHasChanged);
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
        if (_selectedValues != null && _selectedValues.Any())
            _page.ParentBIds = string.Join(",", _selectedValues);
    }

    private void HandleOnTimeRangeChange(DateRangeChangedEventArgs<DateTime?[]> args)
    {
        var dates = args.Dates;
        _page.CreateStartTime = dates[0]?.Date;
        _page.CreateEndTime = dates[1]?.Date.AddDays(1).AddSeconds(-1);
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
