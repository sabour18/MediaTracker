import { Component } from '@angular/core';
import { UserService } from '../../shared/services/user/user.service';
import { User } from '../../shared/models/User';
import { AuthService } from '../../shared/services/auth/auth.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.css'
})
export class HomePageComponent {
  isAuthenticated: boolean = false;
  users: User[] = [];
  username: string | null = null;
  selectedMovie: any = null;
  showTrending = true;

  constructor(private authService: AuthService, private userService: UserService)
  {
    this.username = localStorage.getItem('username');
  }

  ngOnInit(): void {
    this.authService.isAuthenticated().subscribe(isAuthenticated => {
      this.isAuthenticated = isAuthenticated;
    });
  }

  getAllUsers(): void {
    this.userService.getAllUsers().subscribe(users => this.users = users);
  }
}
