using AntDesign;
using Mbill.Admin.Common.Tools;
using Mbill.Admin.Models.Base;
using Mbill.Admin.Services.Impl;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Mbill.Admin.Extensions.Json;

namespace Mbill.Admin.Services.Base;

public class CoreClient
{
    private readonly HttpClient _httpClient;
    private readonly Appsettings _appsettings;
    private readonly AccountStorageJsService _accountStorageJsServic;
    private readonly MessageService _messageService;

    public CoreClient(HttpClient httpClient, IOptions<Appsettings> options, AccountStorageJsService accountStorageJsService, MessageService messageService)
    {
        _appsettings = options.Value;
        httpClient.BaseAddress = new Uri(_appsettings.CoreUrl);
        _httpClient = httpClient;
        _accountStorageJsServic = accountStorageJsService;
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
        return (await BasePostAsync<ServiceResult<TResult>>(url, content, isHint, isUnToken, cancellationToken)).Result;
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
        return (await BasePostAsync<ServiceResult>(url, content, isHint, isUnToken, cancellationToken)).Success;
    }

    /// <summary>
    /// Get 请求
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="url">请求地址</param>
    /// <param name="isUnToken">是否需要token</param>
    /// <returns></returns>
    public async Task<TResult> GetAsync<TResult>(string url, bool isHint = true, bool isUnToken = true, CancellationToken cancellationToken = default) where TResult : new()
    {
        try
        {
            if (isUnToken)
            {
                var token = await _accountStorageJsServic.GetTokenAsync();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            HttpResponseMessage response = null;
            response = await _httpClient.GetAsync(url);

            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    var resultStr = await response.Content.ReadAsStringAsync();
                    var result = resultStr.Deserialize<ServiceResult<TResult>>();
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
                _messageService.Error(ex.Message);

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
    private async Task<T> BasePostAsync<T>(string url, object content = null, bool isHint = true, bool isUnToken = true, CancellationToken cancellationToken = default) where T : ServiceResult, new()
    {
        var bodyJson = content == null ? "" : JsonSerializer.Serialize(content);
        try
        {
            if (isUnToken)
            {
                var token = await _accountStorageJsServic.GetTokenAsync();
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
                    var result = resultStr.Deserialize<T>();
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
                _messageService.Error(ex.Message);
        }
        return new T();

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
            await _accountStorageJsServic.RemoveTokenAsync();
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
            if (!string.IsNullOrWhiteSpace(resultStr))
            {
                result = resultStr.Deserialize<ServiceResult>();
            }
            return result.Message ?? "请求失败，请联系管理员！";
        }
    }

    /// <summary>
    /// 获取拼接Uri(Dictionary)
    /// </summary>
    /// <param name="prefix">请求前缀地址</param>
    /// <param name="parameter">查询参数字典</param>
    /// <returns>Uri</returns>
    public static string GetSpliceUrlByDic(string prefix, Dictionary<string, string> parameter)
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

    /// <summary>
    /// 获取拼接Uri(Object)
    /// </summary>
    /// <param name="prefix">请求前缀地址</param>
    /// <param name="parameter">查询参数字典</param>
    /// <returns>Uri</returns>
    public static string GetSpliceUrlByObj<T>(string prefix, T parameter)
    {
        Type t = parameter.GetType();
        PropertyInfo[] props = t.GetProperties();

        var query = HttpUtility.ParseQueryString(string.Empty);
        foreach (var item in props)
        {
            query[item.Name] = item.GetValue(parameter)?.ToString();
        }
        string queryString = query.ToString();
        var uri = prefix + (string.IsNullOrEmpty(queryString) ? "" : "?") + queryString;
        //进行解码成中文格式，再返回
        string result = HttpUtility.UrlDecode(uri, Encoding.GetEncoding("UTF-8"));
        return result;
    }
    #endregion
}
