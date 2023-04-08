using Microsoft.AspNetCore.SignalR;
using SignalRApiSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SignalRApiSQL.Hubs
{
    public class VisitorHub:Hub
    {
        private readonly VisitorService _vService;

        public VisitorHub(VisitorService vService)
        {
            _vService = vService;
        }

        public CancellationToken GetVisitorChartList { get; private set; }

        public async Task GetVisitorList()
        {
            await Clients.All.SendAsync("ReceiveVisitorList", _vService.GetVisitorChartList());
        }
    }
}
