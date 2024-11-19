import { Component } from '@angular/core';
import { FileUploadModule } from 'primeng/fileupload';
import {HttpClient, HttpHeaders} from '@angular/common/http';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrl: './upload.component.scss'
})
export class UploadComponent {

  constructor(private http:HttpClient) {}

  onUpload(event: any) {
    console.log('Upload event triggered', event);

    const file = event.files[0]; // Assurez-vous d'utiliser le bon format
    const formData = new FormData();
    formData.append('file', file, file.name);

    const headers = new HttpHeaders();

    // Test pour vérifier si l'upload fonctionne
    this.http.post('http://localhost:3130/api/pdf/upload', formData, { headers }).subscribe({
      next: (response) => console.log('Upload successful', response),
      error: (error) => console.error('Upload error', error)
    });
  }

}
