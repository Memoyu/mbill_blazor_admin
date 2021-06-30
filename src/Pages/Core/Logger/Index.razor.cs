using AntDesign;
using AntDesign.TableModels;
using mbill_blazor_admin.Models.Base;
using mbill_blazor_admin.Models.Core.Input;
using mbill_blazor_admin.Models.Core.Output;
using mbill_blazor_admin.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mbill_blazor_admin.Pages.Core.Logger
{
    public partial class Index
    {
        private SelectStringModel[] _methods =
        {
            new SelectStringModel {Id = "", Name="全部", NotAvailable = false  },
            new SelectStringModel {Id = "POST", Name="POST", NotAvailable = false  },
            new SelectStringModel {Id = "PUT", Name="PUT", NotAvailable = false  },
            new SelectStringModel {Id = "DELETE", Name="DELETE", NotAvailable = false  },
            new SelectStringModel {Id = "GET", Name="GET", NotAvailable = false  },
        };

        private SelectStringModel[] _users =
        {
            new SelectStringModel {Id = "", Name="全部", NotAvailable = false  },
        }; 

        private SelectStringModel[] _statusCodes =
        {
            new SelectStringModel {Id = "", Name="全部", NotAvailable = false  },
        };

        private LogModel[] _logs = { };
        private LogPageParams _page = new LogPageParams { };//new UserPageParams { Page = 0, Size = 10 };
        private int _total = 0;
        private bool _loading = false;

        [Inject] protected ICoreService coreService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        private async Task HandleOnSearch()
        {
            await GetLogs();
        }

        private async Task HandleOnReset()
        {
            _page = new LogPageParams();
            await GetLogs();
        }

        private async Task HandelOnChange(QueryModel<LogModel> queryModel)
        {
            await GetLogs();
        }

        private void HandleOnTimeRangeChange(DateRangeChangedEventArgs args)
        {
            var date = args.Dates;
            _page.CreateStartTime = date[0]?.Date;
            _page.CreateEndTime = date[1]?.Date.AddDays(1).AddSeconds(-1);
        }

        private async Task GetLogs()
        {
            _loading = true;
            var log = await coreService.GetLogs(_page);
            _logs = log.Items.ToArray();
            _total = (int)log.Total;
            _loading = false;
        }
    }
}
