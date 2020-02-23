import { Component, OnInit } from '@angular/core';


import { LoginService } from '../services/login.service';
import { UserDto } from '../interfaces/UserDto';

@Component({
  selector: 'app-user-dashboard',
  templateUrl: './user-dashboard.component.html',
  styleUrls: ['./user-dashboard.component.css']
})
export class UserDashboardComponent implements OnInit {

  currentUser: UserDto;
  loggedInUsers: UserDto[];

  constructor(private loginService: LoginService) {

  }

  ngOnInit(): void {
    this.currentUser = this.loginService.getCurrentUser();

    this.loginService.getAllLoggedInUsers().subscribe(data => {
			this.loggedInUsers = data.body;
		});
  }

}
