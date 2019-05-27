import { MatchEntry } from './matchEntry';
import { Player } from './Player';

export class Match {
  id: number;
  whichMatch: number;
  entries: MatchEntry[];
  winner: Player;
}
