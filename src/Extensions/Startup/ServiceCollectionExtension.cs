using mbill_blazor_admin.Services.Base;
using mbill_blazor_admin.Services;
using mbill_blazor_admin.Services.Impl;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.AspNetCore.Components.Authorization;

namespace mbill_blazor_admin.Extensions.Startup
{
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// 注册HttpClient
        /// </summary>
        /// <param name="builder"></param>
        public static void AddCoreHttpClient(this WebAssemblyHostBuilder builder)
        {
            builder.Services.AddHttpClient("local", config => // 本地请求
            {
                config.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
            });
            builder.Services.AddHttpClient<CoreClient>();// MBill WebAPI 服务
        }
        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="services"></param>
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<AuthenticationStateProvider, AuthenticationService>();
            services.AddScoped<ICoreService, CoreService>();
        }

    }
}
