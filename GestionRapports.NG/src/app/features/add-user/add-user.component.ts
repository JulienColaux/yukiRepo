import { Component } from '@angular/core';
import { AddUserService } from '../../core/services/add-user.service';

@Component({
  selector: 'app-add-user', 
  templateUrl: './add-user.component.html',
  styleUrl: './add-user.component.scss'
})
export class AddUserComponent {
  // Initializing the user object with default empty values
  user = { Firstname: '', Lastname: '', Email: '', Password: '', Profil: '', Phone: '' };


  constructor(private addUserService: AddUserService) {}


  onSubmit() {
    // Calling the addUser method from the service to send the data to the API
    this.addUserService.addUser(this.user).subscribe(response => {
      console.log('User added successfully', response); // Logging a success message if the user is added
    }, error => {
      console.error('Error adding user', error); // Logging an error if something goes wrong
    });
  }
}
