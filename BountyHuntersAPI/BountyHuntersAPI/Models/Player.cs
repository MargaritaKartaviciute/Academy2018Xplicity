using System.ComponentModel.DataAnnotations;
using    System.ComponentModel.DataAnnotations.Schema;

namespace BountyHuntersAPI.Models
{
    public class Player
    {   [Key]
        public int PlayerId { get; set; }
        public string Username { get; set; }
        public int MatchsCount { get; set; }
        public int WinningsCount { get; set; }
        public int DefeatsCount { get; set; }
        public int Score { get; set; }
        [ForeignKey("Tournament")]
        public int TournamentId { get; set; }  
    }
}
