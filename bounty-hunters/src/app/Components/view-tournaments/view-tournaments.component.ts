import { Component, OnInit } from '@angular/core';
import { TournamentService } from '../../services/tournament.service';
import { Tournament } from '../../Models/Tournament';
import { AuthenticationService } from '../../services/authentication.service';

@Component({
  selector: 'app-view-tournaments',
  templateUrl: './view-tournaments.component.html',
  styleUrls: ['./view-tournaments.component.scss']
})
export class ViewTournamentsComponent implements OnInit {

  tournaments: Tournament[];
  errorMessage: string;

  constructor(private authService: AuthenticationService, private tournamentService: TournamentService) { }

  ngOnInit() {
  this.tournamentService.getTournaments().subscribe(tournaments => {
    this.tournaments = tournaments;
  }, error => {
     console.error(error);
     this.errorMessage = error.message;
  });

  }

  loggedIn() {
    return this.authService.loggedIn();
  }

}
