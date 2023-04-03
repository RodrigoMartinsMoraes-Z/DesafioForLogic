import { Component, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-tela-login',
  templateUrl: './tela-login.component.html',
  styleUrls: ['./tela-login.component.css']
})

@Injectable({
  providedIn: 'root'
})

export class TelaLoginComponent {
  email: string = '';
  senha: string = '';
  error: string = '';

  constructor(private http: HttpClient) { }

  login() {
    const headers = new HttpHeaders()
      .set('Access-Control-Allow-Origin', '*');

    const payload = {
      email: this.email,
      senha: this.senha
    };

    const httpOptions = {
      headers,
      withCredentials: true,
      rejectUnauthorized: false
    };

    this.http.post('http://localhost:34693/api/Login/realizar-login', payload)
      .subscribe(
        response => console.log(response),
        error => this.error = error.message
      );
  }
}
