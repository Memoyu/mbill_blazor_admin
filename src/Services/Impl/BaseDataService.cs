using System.Collections.Generic;
using System.Threading.Tasks;
using Mbill.Admin.Models.Base.Page;
using Mbill.Admin.Models.BaseData.Input;
using Mbill.Admin.Models.BaseData.Output;
using Mbill.Admin.Services.Base;

namespace Mbill.Admin.Services.Impl;

public class BaseDataService : IBaseDataService
{
    private readonly CoreClient _client;
    public BaseDataService(CoreClient client)
    {
        _client = client;
    }
    public async Task<PagedDto<AssetModel>> GetAssetPages(AssetPageParams pagingDto)
    {
        var url = CoreClient.GetSpliceUrlByObj(BaseDataUrl.GetAssetPages, pagingDto);
        return await _client.GetAsync<PagedDto<AssetModel>>(url);
    }

    public async Task<List<AssetModel>> GetAssetParents()
    {
        return await _client.GetAsync<List<AssetModel>>(BaseDataUrl.GetAssetParents);
    }

    public async Task<PagedDto<CategoryModel>> GetCategoryPages(CategoryPageParams pagingDto)
    {
        var url = CoreClient.GetSpliceUrlByObj(BaseDataUrl.GetCategoryPages, pagingDto);
        return await _client.GetAsync<PagedDto<CategoryModel>>(url);
    }

    public async Task<List<CategoryModel>> GetCategoryParents()
    {
        return await _client.GetAsync<List<CategoryModel>>(BaseDataUrl.GetCategoryParents);
    }
}
