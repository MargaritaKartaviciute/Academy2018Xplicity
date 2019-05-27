import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OverviewComponent } from './Components/overview/overview.component';
import { HomeComponent } from './Components/home/home.component';
import { CreateTournamentComponent } from './Components/create-tournament/create-tournament.component';
import { PageNotFoundComponent } from './Components/page-not-found/page-not-found.component';
import { TournamentRulesComponent } from './Components/tournament-rules/tournament-rules.component';
import { RegisterComponent } from './Components/register/register.component';
import { LoginComponent } from './Components/login/login.component';
import { BracketsComponent} from './components/overview/brackets/brackets.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'register',
    component: RegisterComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'overview/:id/brackets',
    component: BracketsComponent
  },
  {
    path: 'rules',
    component: TournamentRulesComponent
  },
  {
    path: 'overview/:id',
    component: OverviewComponent
  },
  {
    path: 'create-tournament',
    component: CreateTournamentComponent
  },
  {
    path: '**',
    component: PageNotFoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
