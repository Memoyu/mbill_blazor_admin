namespace mbill_blazor_admin.Models.Base
{
    /// <summary>
    /// 服务层响应实体
    /// </summary>
    public class ServiceResult
    {
        public ServiceResult()
        {
            Code = ServiceResultCode.Failed;
        }

        /// <summary>
        /// 响应码
        /// </summary>
        public ServiceResultCode Code { get; set; }

        /// <summary>
        /// 响应信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 成功与否
        /// </summary>
        public bool Success => Code == ServiceResultCode.Succeed;

        /// <summary>
        /// 时间戳（毫秒）
        /// </summary>
        public long Timestamp { set; get; }

    }

    /// <summary>
    /// 服务层响应实体（泛型）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServiceResult<T> : ServiceResult 
    {
        /// <summary>
        /// 响应结果
        /// </summary>
        public T Result { get; set; }
    
    }
}
