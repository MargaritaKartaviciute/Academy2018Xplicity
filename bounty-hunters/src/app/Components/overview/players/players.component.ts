import { Component, OnInit, OnDestroy } from '@angular/core';
import { Tournament } from '../../../Models/Tournament';
import { TournamentService } from '../../../services/tournament.service';
import { ActivatedRoute } from '@angular/router';
import { Player } from '../../../Models/Player';
import { PlayerService } from '../../../services/player.service';
import { VERSION, MatDialog, MatDialogRef, MatSnackBar, MatTableDataSource } from '@angular/material';
import { EditPlayerDialogComponent } from '../edit-player-dialog/edit-player-dialog.component';
import { filter } from 'rxjs/operators';
import { DataService } from '../../../services/data.service';
import { AuthenticationService } from '../../../services/authentication.service';
import { Subscription } from 'rxjs';
import { PlayersHubService } from '../../../services/hubs/players-hub.service';

export interface TournamentPlayers {
  username: string;
  matches: number;
  winnings: number;
  defeats: number;
  w_l_ratio: number;
}
 const DATA: TournamentPlayers[] = [{
  username: '',
  matches: 0,
  winnings: 0,
  defeats: 0,
  w_l_ratio: 0
}];
@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.scss']
})
export class PlayersComponent implements OnInit, OnDestroy {
  version = VERSION;
  id: number;
  tournament: Tournament;
  subscription = new Subscription();
  Math: any;
  private sub: any;
  // DATA: TournamentPlayers[];

  displayedColumns: string[] = ['username', 'matches', 'winnings', 'defeats', 'w_l_ratio'];
  // dataSource = DATA;
  dataSource = new MatTableDataSource(DATA);

  constructor(private tournamentService: TournamentService,
    private route: ActivatedRoute,
    private playerService: PlayerService,
    private data: DataService,
    private dialog: MatDialog,
    private authService: AuthenticationService,
    private snackBar: MatSnackBar,
    private playersHub: PlayersHubService) {
      this.Math = Math;
    }
  editPlayerDialogRef: MatDialogRef<EditPlayerDialogComponent>;



  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id'];
      this.getTournamentById(this.id);
    });
        this.data.currentTournament.subscribe(tournament => {
          this.tournament = tournament;
          this.formNewObject(tournament);
          if (this.tournament.players !== undefined) {
            this.tournament.players.sort((a, b) =>
            a.defeatsCount - b.defeatsCount || b.winningsCount - a.winningsCount);
          }
        });
      const playersHubSubscription = this.playersHub.receivePlayers().subscribe(tournament => {
        this.tournament = tournament;
        this.snackBar.open(`Players has been updated!`, 'Info', {duration: 3000});
      }, error => {
        console.error(error);
        this.snackBar.open(`${error.message}`, 'Error', {duration: 5000});
      });
    this.subscription.add(playersHubSubscription);
  }

   formNewObject(tournament: Tournament) {
     this.dataSource.data = [];
     const data = this.dataSource.data;
     if (tournament.players !== undefined) {
      for (const value of tournament.players) { // expected output: "a" "b" "c"
        const Data: TournamentPlayers = {
          username: value.username as string,
          matches: value.matchsCount,
          winnings: value.winningsCount,
          defeats: value.defeatsCount,
          w_l_ratio: value.winningsCount / Math.abs(value.matchsCount - value.winningsCount) || 0
        };
        data.push(Data);
      }
    }
    this.dataSource.data = data;
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }


  private getTournamentById(id: number) {
    this.tournamentService.getTournamentsById(id).subscribe(data => {
      this.data.changeTournament(data);
    });
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
    this.playersHub.disconnect();
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  openEditDialog(player) {
    this.editPlayerDialogRef = this.dialog.open(EditPlayerDialogComponent,
  {
    data: {
      playerId: player ? player.playerId : 0,
      username: player ?  player.username : ''
    }
  });

  this.editPlayerDialogRef.afterClosed().subscribe(result => {
    if (result != null  ) {
      console.log('result is: ' + result);
      player.username = result;
      this.data.changeTournament(this.tournament);
    }
  });
}

WinLoseRatio(player){
  if (player.winningsCount == 0) {
    return 0;
  }
  if (player.defeatsCount == 0) {
    return 1;
  }
  else {
    return ((player.winningsCount) / (player.winningsCount + player.defeatsCount)).toPrecision(2);
  }
}

}

