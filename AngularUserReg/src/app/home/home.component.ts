import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../shared/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: []
})
export class HomeComponent implements OnInit {
  // initialize userDetails
  userDetails;

  constructor(private router: Router, private service: UserService) { }

  ngOnInit() {
    // lifecycle hook, do this first
    this.service.getUserProfile().subscribe(
      res => {
        this.userDetails = res;
      },
      err => {
        console.log(err);
      }
    );

  }

  onLogout() {
    // just using localStorage to logout
    localStorage.removeItem('token');
    this.router.navigate(['/user/login']);

  }

}
