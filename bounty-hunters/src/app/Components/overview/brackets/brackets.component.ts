import { Component, OnInit, OnDestroy } from '@angular/core';
import { Tournament } from '../../../Models/Tournament';
import { TournamentService } from '../../../services/tournament.service';
import { ActivatedRoute } from '@angular/router';
import { AuthenticationService } from '../../../services/authentication.service';
import { Subscription } from 'rxjs';
import { BracketsHubService } from '../../../services/hubs/brackets-hub.service';
import { MatSnackBar } from '@angular/material';
import { Player } from '../../../Models/Player';

export interface BracketPlayers {
  round: number;
  players: Player [];
}

//const DATA: BracketPlayers[];
@Component({
  selector: 'app-brackets',
  templateUrl: './brackets.component.html',
  styleUrls: ['./brackets.component.scss']
})
export class BracketsComponent implements OnInit, OnDestroy {
  id: number;
  tournament: Tournament;
  subscription = new Subscription();
  private sub: any;
  dataSource: BracketPlayers[];
  bracketsPlayer: BracketPlayers;
  playersInMatch: Player[] = [];

  constructor(private tournamentService: TournamentService,
    private route: ActivatedRoute,
    private authService: AuthenticationService,
    private bracketsHub: BracketsHubService,
    private snackBar: MatSnackBar) {}
  ngOnInit() {
    this.sub = this.route.paramMap.subscribe(params => {
      this.id = +params.get('id');
      this.getTournamentById(this.id);
    });

    const bracketsHubSubscription = this.bracketsHub.receiveBrackets().subscribe(tournament => {
      this.tournament = tournament;
      this.snackBar.open(`Brackets has been updated!`, 'Info', {duration: 3000});
    }, error => {
      console.error(error);
      this.snackBar.open(`${error.message}`, 'Error', {duration: 5000});
    });
    this.subscription.add(bracketsHubSubscription);
  }

  private getTournamentById(id: number) {
    this.tournamentService.getTournamentsById(id).subscribe(data => {
      this.tournament = data;
    });
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
    this.bracketsHub.disconnect();
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  private onUpdateBracketClick() {
    this.tournamentService.updateBracket(this.tournament.tournamentId)
      .subscribe(data => {
        this.tournament = data;
        // this.formNewObject();
        // for ( const item of this.dataSource) {
        //   console.log(item.round);
        //   for ( const kaz of item.players) {
        //     console.log(kaz.username);
        //   }
        // }
        this.bracketsHub.updateBracket(data);
      }, error => {
        this.snackBar.open(`${error.message}`, 'Error', {duration: 5000});
      });
  }

  // formNewObject() {
  //    this.dataSource = [];
  //    this.playersInMatch = [];
  //    let i = 0;
  //    if (this.tournament.players !== undefined) {
  //     for (const value of this.tournament.matches) {
  //         for ( const item of value.entries) {
  //           this.playersInMatch.push(item.matchPlayer);
  //           console.log(this.playersInMatch);
  //         }
  //         if ( value.whichMatch !== this.tournament.matches[i - 1].whichMatch) {
  //           this.bracketsPlayer = {
  //             round: value.whichMatch,
  //             players: this.playersInMatch
  //           };
  //          console.log(this.bracketsPlayer.round);
  //           this.dataSource.push(this.bracketsPlayer);
  //           this.playersInMatch = [];
  //         }
  //         i = i + 1;
  //       }
  //    }
  // }

  private onIncreaseScoreClick(matchId: number, entryId: number, increment: boolean) {
    this.tournamentService.updateTournamentScore(this.tournament.tournamentId, matchId, entryId, increment)
      .subscribe(data => {
        this.tournament = data;
        this.bracketsHub.updateBracket(data);
      });
  }

  private onCreateBracketClick() {
    this.tournamentService.createBracket(this.tournament.tournamentId)
      .subscribe(data => {
        this.tournament = data;
        this.bracketsHub.updateBracket(data);
      });
  }

}

