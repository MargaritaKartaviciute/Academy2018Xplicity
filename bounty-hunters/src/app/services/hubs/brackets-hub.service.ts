import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { environment } from '../../../environments/environment';
import { from, Observable, Subject } from 'rxjs';
import { Tournament } from '../../Models/Tournament';
import { mergeMap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BracketsHubService {

  private connection: HubConnection;

  constructor() {
    this.connection = new HubConnectionBuilder()
      .withUrl(environment.bracketsHubUrl)
      .build();
   }

   private newConnectionObservable(): Observable<void> {
     return from(this.connection.start());
   }

   receiveBrackets(): Observable<Tournament> {
    const bracketsSubject = new Subject<Tournament>();

    // subscribe to receiveUpdatedBrackets methods messages
    this.connection.on('ReceiveUpdatedBrackets', (tournament: Tournament) => {
      bracketsSubject.next(tournament);
    });

    return this.newConnectionObservable()
      .pipe(mergeMap(() => bracketsSubject.asObservable())
    );
   }

   updateBracket(tournament: Tournament) {
     this.connection.invoke('UpdateBracket', tournament);
   }

   disconnect() {
     if (this.connection != null) {
       this.connection.stop();
     }
   }
}
