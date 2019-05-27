import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { PlayerService } from './services/player.service';

import { HomeComponent } from './Components/home/home.component';
import { OverviewComponent } from './Components/overview/overview.component';
import { BracketsComponent } from './components/overview/brackets/brackets.component';
import { ViewTournamentsComponent } from './Components/view-tournaments/view-tournaments.component';
import { CreateTournamentComponent } from './Components/create-tournament/create-tournament.component';
import { MatchesComponent } from './Components/overview/matches/matches.component';
import { SidebarComponent } from './Components/sidebar/sidebar.component';

import {MatInputModule} from '@angular/material/input';
import { FormsModule, FormGroup, ReactiveFormsModule } from '@angular/forms';
import {BrowserAnimationsModule, NoopAnimationsModule} from '@angular/platform-browser/animations';
import {MatButtonModule, MatCheckboxModule, MatSnackBarModule, MatTableModule} from '@angular/material';

import {MatGridListModule} from '@angular/material/grid-list';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatDialogModule} from '@angular/material/dialog';
import { PageNotFoundComponent } from './Components/page-not-found/page-not-found.component';
import { TournamentRulesComponent } from './Components/tournament-rules/tournament-rules.component';
import {MatSelectModule} from '@angular/material/select';
import {MatIconModule} from '@angular/material/icon';
import { RegisterComponent } from './Components/register/register.component';
import { EditPlayerDialogComponent } from './Components/overview/edit-player-dialog/edit-player-dialog.component';
import { LoginComponent } from './Components/login/login.component';
import { AlertComponent } from './Directives/alert/alert.component';
import { ErrorInterceptor } from './helpers/error.interceptor';
import { JwtInterceptor } from './helpers/jwt.interceptor';
import {MatCardModule} from '@angular/material/card';
import { PlayersComponent } from './Components/overview/players/players.component';

@NgModule({
  declarations: [
    AppComponent,
    OverviewComponent,
    HomeComponent,
    ViewTournamentsComponent,
    CreateTournamentComponent,
    MatchesComponent,
    PlayersComponent,
    SidebarComponent,
    BracketsComponent,
    PageNotFoundComponent,
    TournamentRulesComponent,
    RegisterComponent,
    EditPlayerDialogComponent,
    LoginComponent,
    AlertComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatCheckboxModule,
    HttpClientModule,
    NoopAnimationsModule,
    FormsModule,
    MatInputModule,
    MatGridListModule,
    MatTooltipModule,
    MatDialogModule,
    MatSelectModule,
    MatIconModule,
    ReactiveFormsModule,
    MatCardModule,
    MatSnackBarModule,
    MatTableModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
  ],
  bootstrap: [AppComponent],
  entryComponents: [EditPlayerDialogComponent]
})
export class AppModule { }


