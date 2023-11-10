using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Mbill.Admin.Services.Impl;

public class CommonJsService
{
    private readonly IJSRuntime _jsRuntime;
    public CommonJsService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

}
