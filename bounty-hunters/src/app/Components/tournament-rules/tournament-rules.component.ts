import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { Tournament } from '../../Models/Tournament';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { TournamentService } from '../../services/tournament.service';
import { DataService } from '../../services/data.service';
import { RulesSelectValues } from '../../Models/rules-select-values';
import { RulesSelectValuesString } from '../../Models/rules-select-values-string';
import { AuthenticationService } from '../../services/authentication.service';

@Component({
  selector: 'app-tournament-rules',
  templateUrl: './tournament-rules.component.html',
  styleUrls: ['./tournament-rules.component.scss']
})
export class TournamentRulesComponent implements OnInit {

  tournament: Tournament = new Tournament;

  playersInKnockout: RulesSelectValues[] = [
    {value: '4', viewValue: 4},
    {value: '8', viewValue: 8},
    {value: '16', viewValue: 16},
    {value: '32', viewValue: 32},
    {value: '64', viewValue: 64}
  ];

  GoalsToWin: RulesSelectValues[] = [
    {value: '3', viewValue: 3},
    {value: '5', viewValue: 5},
    {value: '7', viewValue: 7},
    {value: '9', viewValue: 9},
    {value: '11', viewValue: 11},
    {value: '13', viewValue: 13},
    {value: '15', viewValue: 15},
    {value: '17', viewValue: 17},
    {value: '19', viewValue: 19},
    {value: '21', viewValue: 21}
  ];
  PlayersInTeam: RulesSelectValuesString[] = [
    {value: '1', viewValue: 'Singles'},
    {value: '2', viewValue: 'Teams'}
  ];
  constructor(private router: Router, private route: ActivatedRoute,
    private tournamentService: TournamentService, private dataService: DataService,
    private authService: AuthenticationService) { }

  ngOnInit() {
    if (!this.authService.loggedIn()) {
      this.router.navigate(['']);
    }
  }

  onAddButtonClick() {
    if (this.tournament.goalsToWin < 1) {
      document.getElementById('error-rules-invalid').style.display = 'block';
    } else {
    if   (!(this.tournament.playersInKnockout === undefined)
    && !(this.tournament.playersInTeam === undefined)
    && !(this.tournament.goalsToWin === undefined)) {
      this.router.navigate(['/create-tournament']);
      this.newTournament();
    } else {
      document.getElementById('error-rules-not-filled').style.display = 'block';
    }
  }

    console.log('this.tournament.playersInKnockout: ' + this.tournament.playersInKnockout);
    console.log('this.tournament.playersInTeam: ' + this.tournament.playersInTeam);
    console.log('this.tournament.goalsToWin: ' + this.tournament.goalsToWin);
}

newTournament() {
  this.dataService.changeTournament(this.tournament);
}

}
