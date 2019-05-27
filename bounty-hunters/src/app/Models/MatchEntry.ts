import { Player } from './Player';
import { Match } from './Match';

export class MatchEntry {
  id: number;
  score: number;
  matchPlayer: Player;
  ParentMatch: Match;
}
