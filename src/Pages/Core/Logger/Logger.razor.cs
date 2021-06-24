using AntDesign.TableModels;
using mbill_blazor_admin.Models.Core;
using mbill_blazor_admin.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mbill_blazor_admin.Pages.Core.Logger
{
    public partial class Logger
    {
        private LogModel[] _logs = { };
        private LogPageParams page = new LogPageParams { };//new UserPageParams { Page = 0, Size = 10 };
        private int _total = 0;
        private bool _loading = false;

        [Inject] protected ICoreService coreService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        private async Task onChange(QueryModel<LogModel> queryModel)
        {
            Console.WriteLine("分页改变");
            await GetLogs();
        }

        private async Task GetLogs()
        {
            _loading = true;
            var log = await coreService.GetLogs(page);
            _logs = log.Items.ToArray();
            _total = (int)log.Total;
            _loading = false;
        }
    }
}
