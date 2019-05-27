using BountyHuntersAPI.Data.Interfaces;
using BountyHuntersAPI.Data.Repositories;
using BountyHuntersAPI.Helpers;
using BountyHuntersAPI.Helpers.Interfaces;
using BountyHuntersAPI.Services;
using BountyHuntersAPI.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BountyHuntersAPI.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ConfigureDependencyInejctions(this IServiceCollection services)
        {
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<IMatchRepository, MatchRepository>();
            services.AddScoped<IMatchService, MatchService>();

            services.AddScoped<ITournamentRepository, TournamentRepository>();
            services.AddScoped<ITournamentService, TournamentService>();

            services.AddScoped<ITournamentPlayerRepository, TournamentPlayerRepository>();
            services.AddScoped<ITournamentPlayerService, TournamentPlayerService>();

            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<ITournamentGroupHelper, TournamentGroupsHelper>();
            services.AddScoped<ITournamentBracketHelper, TournamentBracketHelper>();
            services.AddScoped<ITournamentHelper, TournamentHelper>();

            return services;
        }
    }
}
