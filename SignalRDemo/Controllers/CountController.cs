using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRDemo.Controllers
{
    [Route("api/count")]
    public class CountController : Controller
    {
        private readonly IHubContext<CountHub> _hubContext;

        public CountController(IHubContext<CountHub> hubContext)
        {
            this._hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            await _hubContext.Clients.All.SendAsync("someFunc", new { random = "abcd" });

            return Accepted(1);
        }
    }
}
