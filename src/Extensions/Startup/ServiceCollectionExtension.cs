using Mbill.Admin.Services.Base;
using Mbill.Admin.Services;
using Mbill.Admin.Services.Impl;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.Authorization;

namespace Mbill.Admin.Extensions.Startup;

public static class ServiceCollectionExtension
{
    /// <summary>
    /// 注册HttpClient
    /// </summary>
    /// <param name="services"></param>
    public static void AddCoreHttpClient(this IServiceCollection services)
    {
        services.AddHttpClient<CoreClient>();// MBill WebAPI 服务
    }
    /// <summary>
    /// 注册服务
    /// </summary>
    /// <param name="services"></param>
    public static void AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<AuthenticationStateProvider, AuthenticationService>();
        services.AddScoped<ICoreService, CoreService>();
        services.AddScoped<IBaseDataService, BaseDataService>();
    }

}
