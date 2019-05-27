import { Component, OnInit } from '@angular/core';
import { Tournament } from '../../Models/Tournament';
import { TournamentService } from '../../services/tournament.service';
import { ActivatedRoute } from '@angular/router';
import { Player } from '../../Models/Player';
import { PlayerService } from '../../services/player.service';
import { DataService } from '../../services/data.service';
import { AuthenticationService } from '../../services/authentication.service';

@Component({
  selector: 'app-overview',
  templateUrl: './overview.component.html',
  styleUrls: ['./overview.component.scss']
})
export class OverviewComponent implements OnInit {
  id: number;
  private sub: any;
  // private messageSource = new BehaviorSubject<Tournament>(new Tournament());
  // tournamentObservable = this.messageSource.asObservable();
  tournament: Tournament;

  constructor(private tournamentService: TournamentService,
    // private data: DataService,
    private route: ActivatedRoute,
    private authService: AuthenticationService) { }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id'];
      this.getTournamentById(this.id);
      // this.tournamentService.getTournaments
    });
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  onNewMatchClick() {
    this.tournamentService.updateTournamentMatches(this.tournament.tournamentId).subscribe(data => {
      this.tournament = data;
      // this.tournamentService.
    });
  }

  private getTournamentById(id: number) {
    this.tournamentService.getTournamentsById(id).subscribe(data => {
      this.tournament = data;
    });
  }

}
