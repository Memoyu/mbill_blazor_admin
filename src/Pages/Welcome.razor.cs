using AntDesign.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mbill_blazor_admin.Pages
{
    public partial class Welcome
    {
        #region 示例1

        readonly object uvBillData = new object[]
        {
        new {time = "2019-03", value = 350, type = "uv"},
        new {time = "2019-04", value = 900, type = "uv"},
        new {time = "2019-05", value = 300, type = "uv"},
        new {time = "2019-06", value = 450, type = "uv"},
        new {time = "2019-07", value = 470, type = "uv"},
        new {time = "2019-03", value = 220, type = "bill"},
        new {time = "2019-04", value = 300, type = "bill"},
        new {time = "2019-05", value = 250, type = "bill"},
        new {time = "2019-06", value = 220, type = "bill"},
        new {time = "2019-07", value = 362, type = "bill"}
        };

        readonly object transformData = new object[]
        {
        new {time = "2019-03", count = 800},
        new {time = "2019-04", count = 600},
        new {time = "2019-05", count = 400},
        new {time = "2019-06", count = 380},
        new {time = "2019-07", count = 220}
        };

        readonly GroupedColumnLineConfig config1 = new GroupedColumnLineConfig
        {
            Title = new Title
            {
                Visible = true,
                Text = "分组柱+折线混合图",
                AlignTo = "middle"
            },
            Description = new Description
            {
                Visible = true,
                Text = "分组柱+折线混合图表",
                AlignTo = "middle"
            },
            XField = "time",
            YField = new[] { "value", "count" },
            ColumnGroupField = "type"
        };

        #endregion 示例1
    }
}
