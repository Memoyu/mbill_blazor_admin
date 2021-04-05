using AntDesign;
using mbill_blazor_admin.Common.Tools;
using mbill_blazor_admin.Models.Base;
using mbill_blazor_admin.Services.Impl;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace mbill_blazor_admin.Services.Base
{
    public class CoreClient
    {
        private readonly HttpClient _httpClient;
        private readonly IJSRuntime _jsRuntime;
        private readonly Appsettings _appsettings;
        private readonly AccountStorageService _accountStorageServic;
        private readonly MessageService _messageService;

        public CoreClient(HttpClient httpClient, IJSRuntime jsRuntime, IOptions<Appsettings> options, AccountStorageService accountStorageService, MessageService messageService)
        {
            _appsettings = options.Value;
            httpClient.BaseAddress = new Uri(_appsettings.CoreUrl);
            _httpClient = httpClient;
            _jsRuntime = jsRuntime;
            _accountStorageServic = accountStorageService;
            _messageService = messageService;
        }

        /// <summary>
        /// Post请求(返回结果)
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="url">请求地址</param>
        /// <param name="isUnToken">是否需要token</param>
        /// <param name="content">请求体</param>
        /// <returns></returns>
        public async Task<TResult> PostResultAsync<TResult>(string url, object content = null, bool isHint = true, bool isUnToken = true, CancellationToken cancellationToken = default) where TResult : class
        {
            var res = await BasePostAsync<ServiceResult<TResult>>(url, content, isHint, isUnToken, cancellationToken);
            return res?.Result;
        }


        /// <summary>
        /// Post请求(无返回会结果)
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="isUnToken">是否需要token</param>
        /// <param name="content">请求体</param>
        /// <returns></returns>
        public async Task<bool> PostAsync(string url, object content = null, bool isHint = true, bool isUnToken = true, CancellationToken cancellationToken = default)
        {
            var res = await BasePostAsync<ServiceResult>(url, content, isHint, isUnToken, cancellationToken);
            return res.Success;
        }

        /// <summary>
        /// Get 请求
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="url">请求地址</param>
        /// <param name="isUnToken">是否需要token</param>
        /// <param name="parameter">请求参数</param>
        /// <returns></returns>
        public async Task<TResult> GetAsync<TResult>(string url, Dictionary<string, string> parameter = null, bool isHint = true, bool isUnToken = true, CancellationToken cancellationToken = default) where TResult : new()
        {
            try
            {
                if (parameter != null)
                {
                    url = GetSpliceUrl(url, parameter);
                }
                if (isUnToken)
                {
                    var token = await _accountStorageServic.GetTokenAsync();
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                }
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                if (response != null)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var resultStr = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<ServiceResult<TResult>>(resultStr);
                        if (result.Success)
                        {
                            return result.Result;
                        }
                        else
                        {
                            throw new Exception(result.Message);
                        }
                    }
                    else
                    {
                        await FilterStatusCode(response);
                    }
                }
                else
                {
                    throw new Exception("请求失败，请联系管理员！");
                }
            }
            catch (Exception ex)
            {
                if (isHint)
                    await _messageService.Error(ex.Message);

            }
            return new TResult();
        }

        #region Private

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="isUnToken">是否需要token</param>
        /// <param name="content">请求体</param>
        /// <returns></returns>
        private async Task<T> BasePostAsync<T>(string url, object content = null, bool isHint = true, bool isUnToken = true, CancellationToken cancellationToken = default) where T : ServiceResult
        {
            var bodyJson = content == null ? "" : JsonConvert.SerializeObject(content);
            try
            {
                if (isUnToken)
                {
                    var token = await _accountStorageServic.GetTokenAsync();
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                HttpResponseMessage response;
                using (HttpContent httpContent = new StringContent(bodyJson, Encoding.UTF8))
                {
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    response = await _httpClient.PostAsync(url, httpContent);
                }
                if (response != null)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var resultStr = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<T>(resultStr);
                        if (result.Success)
                        {
                            return result;
                        }
                        else
                        {
                            throw new Exception(result.Message);
                        }
                    }
                    else
                    {
                        await FilterStatusCode(response);
                    }
                }
                else
                {
                    throw new Exception("请求失败，请联系管理员！");
                }
            }
            catch (Exception ex)
            {
                if (isHint)
                    await _messageService.Error(ex.Message);

            }
            return default(T);

        }

        /// <summary>
        /// 过滤状态码
        /// </summary>
        /// <param name="response">响应信息</param>
        /// <returns></returns>
        private async Task FilterStatusCode(HttpResponseMessage response)
        {
            var code = response.StatusCode;

            if (code == HttpStatusCode.Unauthorized || code == HttpStatusCode.UnprocessableEntity)
            {
                await _accountStorageServic.RemoveTokenAsync();
                throw new Exception(await GetResult());
            }
            else if (code == HttpStatusCode.NotFound || code == HttpStatusCode.BadRequest || code == HttpStatusCode.InternalServerError)
            {
                throw new Exception("请求失败，请联系管理员！");
            }
            else
            {
                throw new Exception(await GetResult());
            }

            async Task<string> GetResult()
            {
                ServiceResult result = new ServiceResult();
                var resultStr = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrWhiteSpace(resultStr))
                {
                    result = JsonConvert.DeserializeObject<ServiceResult>(resultStr);
                }
                return result.Message ?? "请求失败，请联系管理员！";
            }
        }

        /// <summary>
        /// 获取拼接Uri
        /// </summary>
        /// <param name="prefix">请求前缀地址</param>
        /// <param name="parameter">查询参数字典</param>
        /// <returns>Uri</returns>
        public static string GetSpliceUrl(string prefix, Dictionary<string, string> parameter)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            foreach (var item in parameter)
            {
                query[item.Key] = item.Value;
            }
            string queryString = query.ToString();
            var uri = prefix + (string.IsNullOrEmpty(queryString) ? "" : "?") + queryString;
            //进行解码成中文格式，再返回
            string result = HttpUtility.UrlDecode(uri, Encoding.GetEncoding("UTF-8"));
            return result;
        }
        #endregion
    }
}
