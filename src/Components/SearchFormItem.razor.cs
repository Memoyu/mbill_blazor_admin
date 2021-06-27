using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace mbill_blazor_admin.Components
{
    public partial class SearchFormItem
    {
        private readonly string _prefixCls = "ant-form-item";

        [Parameter]
        public string Label { get; set; }


        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
