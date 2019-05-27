using BountyHuntersAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BountyHuntersAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
