#pragma checksum "D:\个人记账\blazor_admin\src\mbill_blazor_admin\Pages\Welcome.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "455d350ba6499d19978cc2aaf9b512b97c8432ba"
// <auto-generated/>
#pragma warning disable 1591
namespace mbill_blazor_admin.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\个人记账\blazor_admin\src\mbill_blazor_admin\_Imports.razor"
using AntDesign;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\个人记账\blazor_admin\src\mbill_blazor_admin\_Imports.razor"
using AntDesign.Charts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\个人记账\blazor_admin\src\mbill_blazor_admin\_Imports.razor"
using AntDesign.Pro.Layout;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\个人记账\blazor_admin\src\mbill_blazor_admin\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\个人记账\blazor_admin\src\mbill_blazor_admin\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\个人记账\blazor_admin\src\mbill_blazor_admin\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\个人记账\blazor_admin\src\mbill_blazor_admin\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\个人记账\blazor_admin\src\mbill_blazor_admin\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\个人记账\blazor_admin\src\mbill_blazor_admin\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\个人记账\blazor_admin\src\mbill_blazor_admin\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\个人记账\blazor_admin\src\mbill_blazor_admin\_Imports.razor"
using mbill_blazor_admin;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Welcome : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<AntDesign.Pro.Layout.PageContainer>(0);
            __builder.AddAttribute(1, "Title", "欢迎");
            __builder.AddAttribute(2, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<AntDesign.Card>(3);
                __builder2.AddAttribute(4, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<AntDesign.Alert>(5);
                    __builder3.AddAttribute(6, "Message", "AntDesign.Templates 已经发布到nuget，可以直接下载使用");
                    __builder3.AddAttribute(7, "Type", "success");
                    __builder3.AddAttribute(8, "ShowIcon", true);
                    __builder3.AddAttribute(9, "Banner", true);
                    __builder3.AddAttribute(10, "Style", "margin: -12px; margin-bottom: 24px");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(11, "\n        ");
                    __builder3.OpenComponent<AntDesign.Text>(12);
                    __builder3.AddAttribute(13, "Strong", true);
                    __builder3.AddAttribute(14, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddMarkupContent(15, "<a target=\"_blank\" rel=\"noopener noreferrer\" href=\"https://www.nuget.org/packages/AntDesign.Templates\">\n                使用dotnet快速安装最新模板\n            </a>");
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(16, "\n        ");
                    __builder3.OpenElement(17, "pre");
                    __builder3.AddAttribute(18, "class", "pre");
                    __builder3.OpenElement(19, "code");
                    __builder3.OpenComponent<AntDesign.Text>(20);
                    __builder3.AddAttribute(21, "Copyable", true);
                    __builder3.AddAttribute(22, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddContent(23, " dotnet new --install AntDesign.Templates::0.1.0-*");
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(24, "\n        ");
                    __builder3.OpenComponent<AntDesign.Text>(25);
                    __builder3.AddAttribute(26, "Strong", true);
                    __builder3.AddAttribute(27, "Style", "margin-bottom: 12px");
                    __builder3.AddAttribute(28, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddMarkupContent(29, "<a target=\"_blank\" rel=\"noopener noreferrer\" href=\"https://github.com/ant-design-blazor/ant-design-pro-blazor\">\n                创建wasm空项目\n            </a>");
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(30, "\n        ");
                    __builder3.OpenElement(31, "pre");
                    __builder3.AddAttribute(32, "class", "pre");
                    __builder3.OpenElement(33, "code");
                    __builder3.OpenComponent<AntDesign.Text>(34);
                    __builder3.AddAttribute(35, "Copyable", true);
                    __builder3.AddAttribute(36, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddContent(37, " dotnet new antdesign --host=wasm");
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(38, "\n        ");
                    __builder3.OpenComponent<AntDesign.Text>(39);
                    __builder3.AddAttribute(40, "Strong", true);
                    __builder3.AddAttribute(41, "Style", "margin-bottom: 12px");
                    __builder3.AddAttribute(42, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddMarkupContent(43, "<a target=\"_blank\" rel=\"noopener noreferrer\" href=\"https://github.com/ant-design-blazor/ant-design-pro-blazor\">\n                创建包含所有页面的wasm项目\n            </a>");
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(44, "\n        ");
                    __builder3.OpenElement(45, "pre");
                    __builder3.AddAttribute(46, "class", "pre");
                    __builder3.OpenElement(47, "code");
                    __builder3.OpenComponent<AntDesign.Text>(48);
                    __builder3.AddAttribute(49, "Copyable", true);
                    __builder3.AddAttribute(50, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddContent(51, " dotnet new antdesign --host=wasm --full");
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(52, "\n    ");
                __builder2.AddMarkupContent(53, @"<p style=""text-align: center; margin-top: 24px;"">
        Want to add more pages? Please refer to
        <a href=""https://github.com/ant-design-blazor/ant-design-pro-blazor"" target=""_blank"" rel=""noopener noreferrer"">
            ant-design-pro-blazor project
        </a>
        。
    </p>");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
