import { Component } from '@angular/core';
import { User } from '../../../core/models/user';
import { LoginService } from '../../../core/services/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})



export class LoginComponent {

  email: string = '';
  password: string = '';

  constructor(private loginService: LoginService, private route: Router) { }


  //  If the user is found and the password matches, the user is redirected to the home page.
  //  If the password is incorrect or the user doesn't exist, an error message is logged.
  //  In case of a retrieval error, an error is logged.

  login(email: string, password: string): void {
    this.loginService.getUserByEmail(email).subscribe({
      next: (user) => {
        if (user) {
          if (user.password === password) {
            console.log('Connexion réussie');
            this.route.navigate(['/home'])
          } else {
            console.error('Mot de passe incorrect');
          }
        } else {
          console.error('Utilisateur non trouvé');
        }
      },
      error: (err) => {
        console.error('Erreur lors de la récupération de l\'utilisateur:', err);
      }
    });
  }
}
