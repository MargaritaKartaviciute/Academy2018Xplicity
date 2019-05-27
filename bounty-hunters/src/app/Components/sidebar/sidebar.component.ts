import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../services/authentication.service';
import {Router} from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})

export class SidebarComponent implements OnInit {

  private sub: any;
  route: string;

  myLocation: Location;


  constructor(private authService: AuthenticationService,
    private router: Router, location: Location) {
      router.events.subscribe((val) => {
        if ((location.path().endsWith('/brackets')) ||
        (location.path().endsWith('/rules')) ||
        (location.path().endsWith('/login')) ||
        (location.path().endsWith('/register')) ||
        (location.path().endsWith('/create-tournament'))) {
          this.route = '';
        } else if (location.path() !== '') {
          this.route = location.path() + '/brackets';
        } else {
          this.route = '';
        }
      });

    }

  ngOnInit() {
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  logout() {
    this.router.navigate(['']);
    // this.route = this + '/brackets';
    return this.authService.logout();
  }

  isShown(): boolean {
     if (this.route === '' ) { return false;
     } else {
       return true;
     }
  }

}
