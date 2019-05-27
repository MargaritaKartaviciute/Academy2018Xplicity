using BountyHuntersAPI.Models;

namespace BountyHuntersAPI.Helpers.Interfaces
{
    public interface ITournamentBracketHelper
    {
        Tournament CreateBracket(Tournament tournament);
        Tournament UpdateBracket(Tournament tournament);
    }
}
