using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SignalRDemo
{
    //[Authorize]
    public class CountHub : Hub
    {
        private readonly CountService _countService;

        public CountHub(CountService countService)
        {
            this._countService = countService;
        }

        public async Task GetLatestCount(string random)
        {
            //var user = Context.User.Identity.Name;
            int count;
            do
            {
                count = _countService.GetLatesCount();

                Thread.Sleep(1000);

                await Clients.All.SendAsync("Update", count);

            } while (count < 10);

            await Clients.All.SendAsync("End");
        }

        public override async Task OnConnectedAsync()
        {
            //var connentionId = Context.ConnectionId;
            //var client = Clients.Client(connentionId);

            //await client.SendAsync("someFunc", new { });
            //await Clients.AllExcept(connentionId).SendAsync("someFunc");

            //await Groups.AddToGroupAsync(connentionId, "MyGroup");
            //await Groups.RemoveFromGroupAsync(connentionId, "MyGroup");

            //await Clients.Groups("MyGroup").SendAsync("someFunc");

        }
    }
}
