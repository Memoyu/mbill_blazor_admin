using Microsoft.AspNetCore.Components;

namespace Mbill.Admin.Components;

public partial class SearchFormItem
{
    private readonly string _prefixCls = "ant-form-item";

    [Parameter]
    public string Label { get; set; }


    [Parameter]
    public RenderFragment ChildContent { get; set; }
}
