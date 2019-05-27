using System.Threading.Tasks;
using BountyHuntersAPI.Models;
using Microsoft.AspNetCore.SignalR;

namespace BountyHuntersAPI.Hubs
{
    public class PlayersHub : Hub
    {
        public async Task UpdatePlayers(Tournament tournament)
        {
            await Clients.Others.SendAsync("ReceiveUpdatedPlayers", tournament);
        }
    }
}
