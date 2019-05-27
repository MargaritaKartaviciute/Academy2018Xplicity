import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '../../../../node_modules/@aspnet/signalr';
import { environment } from '../../../environments/environment';
import { Observable, from, Subject } from '../../../../node_modules/rxjs';
import { Tournament } from '../../Models/Tournament';
import { mergeMap } from '../../../../node_modules/rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PlayersHubService {

  private connection: HubConnection;

  constructor() {
    this.connection = new HubConnectionBuilder()
      .withUrl(environment.playersHubUrl)
      .build();
   }

   private newConnectionObservable(): Observable<void> {
     return from(this.connection.start());
   }

   receivePlayers(): Observable<Tournament> {
    const playersSubject = new Subject<Tournament>();

    // subscribe to ReceiveUpdatedMatches methods messages
    this.connection.on('ReceiveUpdatedPlayers', (tournament: Tournament) => {
      playersSubject.next(tournament);
    });

    return this.newConnectionObservable()
      .pipe(mergeMap(() => playersSubject.asObservable())
    );
   }

   updatePlayers(tournament: Tournament) {
     this.connection.invoke('UpdatePlayers', tournament);
   }

   disconnect() {
     if (this.connection != null) {
       this.connection.stop();
     }
   }
}
