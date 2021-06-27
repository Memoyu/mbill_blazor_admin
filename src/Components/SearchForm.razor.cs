using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntDesign;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace mbill_blazor_admin.Components
{
    public partial class SearchForm : AntDomComponentBase
    {
        private readonly string _prefixCls = "ant-form";

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnSearch { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnRest { get; set; }


        private async Task HandleOnSearch(MouseEventArgs args)
        {
            if (OnSearch.HasDelegate)
            {
                await OnSearch.InvokeAsync(args);
            }
        }

        private async Task HandleOnRest(MouseEventArgs args)
        {
            if (OnRest.HasDelegate)
            {
                await OnRest.InvokeAsync(args);
            }
        }
    }
}
