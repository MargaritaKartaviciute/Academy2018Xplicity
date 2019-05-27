import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Tournament } from '../../Models/Tournament';
import { NgForm } from '@angular/forms';
import { TournamentService } from '../../services/tournament.service';
import { Player } from '../../Models/Player';
import { Router } from '@angular/router';
import { DataService } from '../../services/data.service';
import { AuthenticationService } from '../../services/authentication.service';

@Component({
  selector: 'app-create-tournament',
  templateUrl: './create-tournament.component.html',
  styleUrls: ['./create-tournament.component.scss']
})
export class CreateTournamentComponent implements OnInit {

  playerUsername: string;
  tournament: Tournament = new Tournament();
  playerAlreadyExists: boolean;
  selectedRule: string;
  formCompletedSuccessfuly = false;
  constructor(private router: Router, private tournamentService: TournamentService,
    private dataService: DataService, private authService: AuthenticationService) { }

  ngOnInit() {
    if (!this.authService.loggedIn()) {
      this.router.navigate(['']);
    }
    this.dataService.currentTournament.subscribe(tournament => {
      this.tournament = tournament;
    });
    this.tournament.players = new Array();
    this.playerUsername = '';
  }

  onSubmit(form: NgForm) {
     if (this.formCompletedSuccessfuly) {
       form.resetForm();
     }
  }

  addContact() {
    document.getElementById('error-label-add-tournament').style.display = 'none';
    const customObj = new Player();
    customObj.playerId = 0;
    customObj.username = this.playerUsername;
    customObj.matchsCount = 0;
    customObj.winningsCount = 0;
    customObj.defeatsCount = 0;
    customObj.score = 0;
    this.playerAlreadyExists = false;
    document.getElementById('error-label-player-add').style.display = 'none';
    this.tournament.players.forEach( element => {
      if (element.username === this.playerUsername) {
        this.playerAlreadyExists = true;
      }
    });
    if (this.playerUsername.trim() !== '' && !this.playerAlreadyExists) {
      this.tournament.players.push(customObj);
    } else {
      document.getElementById('error-label-player-add').style.display = 'block';
    }

    customObj.username = this.playerUsername;
    this.playerUsername = '';
  }

  filterPlayers(username: string) {
    this.tournament.players = this.tournament.players.filter(x => x.username !== username);
  }

  onAddButtonClick() {
    console.log(this.tournament);
    document.getElementById('error-label-add-tournament').style.display = 'none';
    if (this.tournament.playersInKnockout <= this.tournament.players.length) {
      this.tournamentService.addTournament(this.tournament)
        .subscribe(savedTournament => {
          this.router.navigate(['/overview/', savedTournament.tournamentId]);
      });
      this.formCompletedSuccessfuly = true;
    } else {
      document.getElementById('error-label-add-tournament').style.display = 'block';
      console.log(this.tournament.playersInKnockout);
    }
  }
}


