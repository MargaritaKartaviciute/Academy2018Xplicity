using System.Threading.Tasks;
using BountyHuntersAPI.Models;
using Microsoft.AspNetCore.SignalR;

namespace BountyHuntersAPI.Hubs
{
    public class BracketsHub : Hub
    {
        public async Task UpdateBracket(Tournament tournament)
        {
            await Clients.Others.SendAsync("ReceiveUpdatedBrackets", tournament);
        }
    }
}
