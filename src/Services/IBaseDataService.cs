using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mbill_blazor_admin.Models.Base.Page;
using mbill_blazor_admin.Models.BaseData.Input;
using mbill_blazor_admin.Models.BaseData.Output;

namespace mbill_blazor_admin.Services
{
    public interface IBaseDataService
    {
        /// <summary>
        /// 获取资产分类分页信息
        /// </summary>
        /// <param name="pagingDto"></param>
        /// <returns></returns>
        Task<PagedDto<AssetModel>> GetAssetPages(AssetPageParams pagingDto);

        /// <summary>
        /// 获取父类资产分类集合
        /// </summary>
        /// <returns></returns>
        Task<List<AssetModel>> GetAssetParents();
    }
}
