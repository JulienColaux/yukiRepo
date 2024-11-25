import { Component } from '@angular/core';
import { User } from '../../../core/models/user';
import { LoginService } from '../../../core/services/login.service';
import { Router } from '@angular/router';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {UserLogin} from '../../../core/models/userLogin';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})



export class LoginComponent {

  errorMessage: string = '';
  loginForm!: FormGroup;


  constructor(
    private loginService: LoginService,
    private route: Router,
    private fb: FormBuilder) { }


  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }


  login(): void {
    if (this.loginForm.valid) {
      const userData = {
        email: this.loginForm.value.email,
        MotsDePasse: this.loginForm.value.password
      };

      console.log(userData);
      this.loginService.login(userData).subscribe({
        next: (response) => {
          console.log(response);
          this.loginService.setToken(response.token);
          localStorage.setItem('userId', response.userId);
          this.route.navigate(['/home']);
        },
        error: (error) => {
          console.error('Login error:', error);
          this.errorMessage = 'Email ou mot de passe incorrect.';
        }
      });
    }
    else {
      console.error('Form invalid');
    }
  }
}
