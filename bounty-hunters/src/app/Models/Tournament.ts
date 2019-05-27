import { Player } from './Player';
import { Match } from './Match';

export class Tournament {
  tournamentId: number;
  name: string;
  players: Player[];
  matches: Match[];
  matchesCount: number;
  currentMatch: number;
  playersInKnockout: number;
  playersInTeam: number;
  goalsToWin: number;
}
