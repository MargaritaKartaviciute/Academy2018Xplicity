﻿namespace BountyHuntersAPI.Dtos.Players
{
    public class PlayerDto
    {
        public string Username { get; set; }
        public int MatchsCount { get; set; }
        public int WinningsCount { get; set; }
        public int DefeatsCount { get; set; }
        public int Score { get; set; }
    }
}
