using System.Threading.Tasks;
using BountyHuntersAPI.Models;
using Microsoft.AspNetCore.SignalR;

namespace BountyHuntersAPI.Hubs
{
    public class MatchesHub : Hub
    {
        public async Task UpdateMatch(Tournament tournament)
        {
            await Clients.Others.SendAsync("ReceiveUpdatedMatches", tournament);
        }
    }
}
