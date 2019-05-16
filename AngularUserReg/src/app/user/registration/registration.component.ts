import { Component, OnInit } from '@angular/core';
import { UserService } from '../../shared/user.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styles: []
})
export class RegistrationComponent implements OnInit {

  constructor(public service: UserService, private toastr: ToastrService, private router: Router) { }

  ngOnInit() {
  }

  onSubmit(form) {
    const user = {
      Email: form.value.Email,
      Password: form.value.Passwords.Password
    };
    this.service.register().subscribe(
      (res: any) => {
        if (res.succeeded) {
          this.service.formModel.reset();
          this.toastr.success('New user created', 'Registration successful');
          this.login(user);
        } else {
          res.errors.forEach(element => {
            switch (element.code) {
              case 'DuplicateUserName':
              this.toastr.error('Username is already taken', 'Registration failed');
              // Username already taken
              break;
              default:
              this.toastr.error(element.description, 'Registration failed');
              // registration failed
              break;
            }
          });
        }
      },
      err => {
        console.log(err);
      }
      );
    }

    login(data) {
      this.service.login(data).subscribe(
        (res: any) => {
          localStorage.setItem('token', res.token);
          this.router.navigateByUrl('/home');
        },
        err => {
          if (err.status === 400) {
            this.toastr.error('Incorrect email or password', 'Authentication failed');
          } else {
            console.log(err);
          }
        }
      );
    }
  }

