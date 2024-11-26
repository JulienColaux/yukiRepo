import { Component } from '@angular/core';
import {User} from '../../core/models/user';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';

@Component({
  selector: 'app-edit-profil',
  templateUrl: './edit-profil.component.html',
  styleUrl: './edit-profil.component.scss'
})
export class EditProfilComponent {

  private apiUrl = 'https://localhost:44312/api/User';

  users: User[] = [];
  editMode: boolean = false;
  deleteMode: boolean = false;
  profil: string = '';
  selectedUserId: number | null = null;

  notificationMessage: string = '';
  notificationType: 'success' | 'error' | '' = '';

  constructor(
    private http: HttpClient
  ) {}

  normalizeUserKeys(user: any): any {
    const normalizedUser: any = {};

    for (const key in user) {
      if (user.hasOwnProperty(key)) {
        if (key.toLowerCase() === 'Email') {
        } else {
          const normalizedKey = this.normalizeKey(key);
          normalizedUser[normalizedKey] = user[key];
        }
      }
    }

    return normalizedUser;
  }

  normalizeKey(key: string): string {
    if (key.toLowerCase() === 'user_id') {
      return 'User_Id';
    }

    return key.charAt(0).toUpperCase() + key.slice(1).toLowerCase();
  }

  getProfileName(profileId: number): string {
    switch (profileId) {
      case 1:
        return 'Equipe Interne';
      case 2:
        return 'Super Utilisateur';
      case 3:
        return 'Lecteur';
      default:
        return 'Inconnu';
    }
  }


  ngOnInit(): void {
    this.getAllUsers().subscribe({
      next: (users: User[]): void => {
        console.log('Users fetched successfully', users);

        this.users = users.map(user => this.normalizeUserKeys(user));

        this.users.forEach(user => {
          if (user.Profil !== undefined && user.Profil !== null) {
            user.Profil = Number(user.Profil);
            user.ProfilName = this.getProfileName(Number(user.Profil));
            console.log(user.ProfilName);
          }
        });
      },
      error: (error: any): void => {
        console.error('Error while fetching users', error);
      }
    });
  }

  getAllUsers(): Observable<User[]> {
    return this.http.get<User[]>(`${this.apiUrl}/getAllUsers`)
  }

  editUser(id: number) {
    console.log('Edit user', id);
    this.editMode = !this.editMode;
    this.selectedUserId = id;
  }

  // confirmEdit(id: number) {
  //   this.selectedUserId = id;
  //
  //
  //   this.http.patch(this.apiUrl+`${id}`, {profil: this.profil}).subscribe({
  //     next: (response) => {
  //       console.log('User updated successfully', response);
  //
  //       const userIndex = this.users.findIndex((user:User) => user.User_Id === id);
  //       if (userIndex !== -1) {
  //         this.users[userIndex].Profil = Number(this.profil);
  //       }
  //
  //       this.showNotification('User updated successfully', 'success');
  //     },
  //     error: (error) => {
  //       console.error('Error while updating user', error);
  //     }
  //   })
  //
  //   this.editMode = false;
  // }

  Delete(id: number) {
    this.selectedUserId = id;
    this.deleteMode = !this.deleteMode;
  }

  deleteUser(id: number) {

    this.http.delete(this.apiUrl+`${id}`).subscribe({
      next: (response) => {
        this.users = this.users.filter((user:User) => user.User_Id !== id);
        this.showNotification('User deleted successfully', 'success');
      },
      error: (error) => {
        this.showNotification('Error while deleting user', 'error');
      }
    });
  }



  showNotification(message: string, type: 'success' | 'error') {
    this.notificationMessage = message;
    this.notificationType = type;

    setTimeout(() => {
      this.notificationMessage = '';
      this.notificationType = '';
    }, 3000);
  }

  roleOptions = [
    { label: 'Equipe Interne', value: 1 },
    { label: 'Super Utilisateur', value: 2 },
    { label: 'Lecteur', value: 3 }
  ];

  confirmEdit(id: number) {
    this.selectedUserId = id;
    console.log(this.selectedUserId)

    const updatedUser = {
      profil: this.profil,
      User_Id: id
    };

    const token = localStorage.getItem('auth_token');
    console.log('Token:', token);

    const headers = new HttpHeaders({
      'Authorization': `bearer ${token}`,
      'Content-Type': 'application/json'
    });

    if (this.profil) {
      this.http.patch(this.apiUrl + `/editProfil`, updatedUser, {headers}).subscribe({
        next: (response) => {
          console.log('User updated successfully', response);

          const userIndex = this.users.findIndex((user: User) => user.User_Id === id);
          if (userIndex !== -1) {
            this.users[userIndex].Profil = Number(this.profil);
            this.users[userIndex].ProfilName = this.getProfileName(Number(this.profil));
          }

          this.showNotification('User updated successfully', 'success');
        },
        error: (error) => {
          console.error('Error while updating user', error);
          this.showNotification('Error while updating user', 'error');
        }
      });

      this.editMode = false;
    }
  }

  cancelEdit() {
    this.editMode = false;
    this.selectedUserId = null;
    this.profil = '';
  }



}

