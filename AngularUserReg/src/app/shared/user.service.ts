import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private fb: FormBuilder, private http: HttpClient) { }
  readonly BaseURL = 'https://localhost:5001/api';

  // this is a form we built, it has the fields we need to send, with validators
  formModel = this.fb.group({
    UserName: ['', Validators.required],
    Email: ['', Validators.email],
    FullName: [''],
    Address: ['', Validators.required],
    PhoneNumber: ['', Validators.required],
    EmergencyNumber: ['', Validators.required],
    EmergencyName: ['', Validators.required],
    EventCode: ['', Validators.required],
    Passwords : this.fb.group({
      Password: ['', [Validators.required, Validators.minLength(4)]],
      ConfirmPassword: ['', Validators.required]
    }, {validator: this.comparePasswords})
  });

  // We made this method to compare passwords. We set errors if they dont match
  comparePasswords(fb: FormGroup) {
    const confirmPswrdCtrl = fb.get('ConfirmPassword');
    // passwordMismatch
    // confirmPswrdCtrl.errors={required:true}
    if (confirmPswrdCtrl.errors == null || 'passwordMismatch' in confirmPswrdCtrl.errors) {
// tslint:disable-next-line: triple-equals
      if (fb.get('Password').value != confirmPswrdCtrl.value) {
        confirmPswrdCtrl.setErrors({passwordMismatch: true});
      } else {
        confirmPswrdCtrl.setErrors(null);
      }
    }
  }

  // sign up method
  register() {
    let body = {
      UserName: this.formModel.value.UserName,
      Email: this.formModel.value.Email,
      FullName: this.formModel.value.FullName,
      Password: this.formModel.value.Passwords.Password,
      Address: this.formModel.value.Address,
      PhoneNumber: this.formModel.value.PhoneNumber,
      EmergencyName: this.formModel.value.EmergencyName,
      EmergencyNumber: this.formModel.value.EmergencyNumber,
      EventCode: this.formModel.value.EventCode
    };
    return this.http.post(this.BaseURL + '/ApplicationUser/Register', body);
  }

  login(formData) {
    return this.http.post(this.BaseURL + '/ApplicationUser/Login', formData);
  }

  getUserProfile() {
    return this.http.get(this.BaseURL + '/UserProfile');
  }
}
