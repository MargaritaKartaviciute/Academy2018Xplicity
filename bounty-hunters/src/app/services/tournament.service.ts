import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { Tournament } from '../Models/Tournament';

@Injectable({
  providedIn: 'root'
})
export class TournamentService {

  private readonly tournamentApi = `${environment.webApiUrl}/tournaments`;
  constructor(private http: HttpClient) { }

  private readonly httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  getTournaments(): Observable<Tournament[]> {
    return this.http.get<Tournament[]>(this.tournamentApi);
  }

  getTournamentsById(id: number): Observable<Tournament> {
    return this.http.get<Tournament>(this.tournamentApi + '/' + id);
  }

  addTournament(tournament: Tournament): Observable<Tournament> {
    return this.http.post<Tournament>(this.tournamentApi, tournament, this.httpOptions);
  }

  updateTournamentMatches(id: number): Observable<Tournament> {
    return this.http.put<Tournament>(this.tournamentApi + '/' + id, this.httpOptions);
  }

  updateTournamentScore(id: number, matchId: number, entryId: number, increment: boolean): Observable<Tournament> {
    return this.http.put<Tournament>(this.tournamentApi + '/' + id + '/match/' + matchId + '/entry/'
    + entryId + '/increment/' + increment, this.httpOptions);
  }

   updateTournament (id: number, tournament: Tournament): Observable<Tournament> {
    return this.http.put<Tournament>(this.tournamentApi + '/' + id + '/rules', tournament, this.httpOptions);
  }

  createBracket(id: number): Observable<Tournament> {
    return this.http.put<Tournament>(this.tournamentApi + '/' + id + '/brackets/create', this.httpOptions);
  }

  updateBracket(id: number): Observable<Tournament> {
    return this.http.put<Tournament>(this.tournamentApi + '/' + id + '/brackets/update', this.httpOptions);
  }

}
