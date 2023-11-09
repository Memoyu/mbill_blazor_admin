using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mbill.Admin.Models.Base.Page;
using Mbill.Admin.Models.BaseData.Input;
using Mbill.Admin.Models.BaseData.Output;

namespace Mbill.Admin.Services
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

        /// <summary>
        /// 获取账单分类分页信息
        /// </summary>
        /// <param name="pagingDto"></param>
        /// <returns></returns>
        Task<PagedDto<CategoryModel>> GetCategoryPages(CategoryPageParams pagingDto);

        /// <summary>
        /// 获取父类账单分类集合
        /// </summary>
        /// <returns></returns>
        Task<List<CategoryModel>> GetCategoryParents();
    }
}
