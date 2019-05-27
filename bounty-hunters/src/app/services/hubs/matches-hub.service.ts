import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '../../../../node_modules/@aspnet/signalr';
import { environment } from '../../../environments/environment';
import { Observable, from, Subject } from '../../../../node_modules/rxjs';
import { Tournament } from '../../Models/Tournament';
import { mergeMap } from '../../../../node_modules/rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class MatchesHubService {
  private connection: HubConnection;

  constructor() {
    this.connection = new HubConnectionBuilder()
      .withUrl(environment.matchesHubUrl)
      .build();
   }

   private newConnectionObservable(): Observable<void> {
     return from(this.connection.start());
   }

   receiveMatches(): Observable<Tournament> {
    const matchesSubject = new Subject<Tournament>();

    // subscribe to ReceiveUpdatedMatches methods messages
    this.connection.on('ReceiveUpdatedMatches', (tournament: Tournament) => {
      matchesSubject.next(tournament);
    });

    return this.newConnectionObservable()
      .pipe(mergeMap(() => matchesSubject.asObservable())
    );
   }

   updateMatch(tournament: Tournament) {
     this.connection.invoke('UpdateMatch', tournament);
   }

   disconnect() {
     if (this.connection != null) {
       this.connection.stop();
     }
   }
}
