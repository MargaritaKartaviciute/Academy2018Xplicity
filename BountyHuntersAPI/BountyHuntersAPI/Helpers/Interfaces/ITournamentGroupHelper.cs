using BountyHuntersAPI.Models;

namespace BountyHuntersAPI.Helpers.Interfaces
{
    public interface ITournamentGroupHelper
    {
        Tournament OtherGroupRounds(Tournament tournament);
    }
}
