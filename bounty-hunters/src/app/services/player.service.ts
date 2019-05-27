import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Player } from '../Models/Player';
import { map } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PlayerService {
  private readonly playerApi = `${environment.webApiUrl}/players`;
  constructor(private http: HttpClient) { }

  private readonly httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  getUsers(): Observable<Player[]> {
    return this.http.get<Player[]>(this.playerApi);
  }

  getPlayerById(id: number): Observable<Player> {
    return this.http.get<Player>(this.playerApi + '/' + id);
  }

  /** PUT: update the hero on the server */
  updatePlayer (player: Player): Observable<any> {
    console.log(player);
    return this.http.put<Player>(this.playerApi + '/' + player.playerId, player, this.httpOptions);
  }

}
