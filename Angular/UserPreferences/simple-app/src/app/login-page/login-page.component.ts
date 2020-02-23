import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

import { LoginService } from '../services/login.service';
import { UserDto } from '../interfaces/UserDto';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {
  loginForm: FormGroup;

  constructor(private loginService: LoginService, private formBuilder: FormBuilder) {
    this.loginForm = this.formBuilder.group({
      userNickName: '',
      isGraduated: false,
      isProgrammer: false
    });
  }

  ngOnInit(): void {
  }

  onSubmit(userData: UserDto): void {
    // Process Checkout Data here
    console.warn(`Your order has been submitted with Name: ${userData.userNickName} Graduated: ${userData.isGraduated} Programmer: ${userData.isProgrammer}`);

    this.loginService.loginIntoApplication(userData).subscribe((result) => {
      console.log('User Added');
    }, (err) => {
      console.log(err);
    });
  }

}
