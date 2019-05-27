import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Tournament } from '../Models/Tournament';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  tournament: Tournament = new Tournament();
  private tournamentSource = new BehaviorSubject<Tournament>(this.tournament);
  currentTournament: Observable<Tournament>;

  constructor() {this.currentTournament = this.tournamentSource.asObservable(); }

  changeTournament(tournament: Tournament) {
    this.tournamentSource.next(tournament);
  }
}
