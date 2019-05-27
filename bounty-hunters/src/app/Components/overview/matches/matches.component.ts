import { Component, OnInit, OnDestroy } from '@angular/core';
import { Tournament } from '../../../Models/Tournament';
import { TournamentService } from '../../../services/tournament.service';
import { ActivatedRoute } from '@angular/router';
import { DataService } from '../../../services/data.service';
import { AuthenticationService } from '../../../services/authentication.service';
import { Subscription } from 'rxjs';
import { BracketsHubService } from '../../../services/hubs/brackets-hub.service';
import { MatSnackBar } from '@angular/material';
import { MatchesHubService } from '../../../services/hubs/matches-hub.service';
import { PlayersHubService } from '../../../services/hubs/players-hub.service';

@Component({
  selector: 'app-matches',
  templateUrl: './matches.component.html',
  styleUrls: ['./matches.component.scss']
})
export class MatchesComponent implements OnInit, OnDestroy {
  id: number;
  tournament: Tournament;
  subscription = new Subscription();
  private sub: any;

  constructor(private tournamentService: TournamentService,
    private data: DataService,
    private route: ActivatedRoute,
    private authService: AuthenticationService,
    private matchesHub: MatchesHubService,
    private playersHub: PlayersHubService,
    private snackBar: MatSnackBar) { }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id'];
      this.getTournamentById(this.id);
      this.data.currentTournament.subscribe(tournament => {
        this.tournament = tournament;
        console.log(tournament);
      });
    });

    const matchesHubSubscription = this.matchesHub.receiveMatches().subscribe(tournament => {
      this.tournament = tournament;
      this.snackBar.open(`Matches has been updated!`, 'Info', {duration: 3000});
    }, error => {
      console.error(error);
      this.snackBar.open(`${error.message}`, 'Error', {duration: 5000});
    });
    this.subscription.add(matchesHubSubscription);
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  private onAddMatchClick() {
    this.tournamentService.updateTournamentMatches(this.tournament.tournamentId)
      .subscribe(data => {
        // this.tournament = data;
        this.data.changeTournament(data);
        this.matchesHub.updateMatch(data);
        this.playersHub.updatePlayers(data);
      });
  }

  private onIncreaseScoreClick(matchId: number, entryId: number, increment: boolean) {
    this.tournamentService.updateTournamentScore(this.tournament.tournamentId, matchId, entryId, increment)
      .subscribe(data => {
        // this.tournament = data;
        this.data.changeTournament(data);
        this.matchesHub.updateMatch(data);
        this.playersHub.updatePlayers(data);
      });
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
    this.matchesHub.disconnect();
    this.playersHub.disconnect();
  }

  private getTournamentById(id: number) {
    this.tournamentService.getTournamentsById(id).subscribe(data => {
      // this.tournament = data;
      this.data.changeTournament(data);
    });
  }
}
