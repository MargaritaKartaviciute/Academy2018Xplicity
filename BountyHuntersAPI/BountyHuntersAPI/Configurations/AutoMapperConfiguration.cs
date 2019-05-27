using AutoMapper;
using BountyHuntersAPI.Dtos.Matches;
using BountyHuntersAPI.Dtos.Players;
using BountyHuntersAPI.Dtos.Tournaments;
using BountyHuntersAPI.Models;

namespace BountyHuntersAPI.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration() : this("AcademyDemo")
        {

        }

        protected AutoMapperConfiguration(string name) : base(name)
        {
            CreateMap<AllPlayersDto, Player>(MemberList.None);
            CreateMap<NewPlayerDto, Player>(MemberList.None);
            CreateMap<PlayerDto, Player>(MemberList.None);
            CreateMap<Player, PlayerDto>(MemberList.Destination);

            CreateMap<AllMatchesDto, Match>(MemberList.None);
            CreateMap<NewMatchDto, Match>(MemberList.None);
            CreateMap<MatchDto, Match>(MemberList.None);
            CreateMap<Match, MatchDto>(MemberList.Destination);

            CreateMap<AllTournamentsDto, Tournament>(MemberList.None);
            CreateMap<NewTournamentDto, Tournament>(MemberList.None);
            CreateMap<TournamentDto, Tournament>(MemberList.None);
            CreateMap<Tournament, TournamentDto>(MemberList.Destination);

        }
    }
}
