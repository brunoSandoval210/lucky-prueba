import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';

export interface UserWithoutId {
  nombre: string;
  apellido: string;
  dni: string;
  sueldo: number;
  departamento_id: number;
}

@Injectable({
  providedIn: 'root'
})

export class UserService {
  private apiUrl='https://localhost:7295/Usuario';
  private users: User[] = [];
  constructor(private http:HttpClient) { }

  findAll(): Observable<User[]> {
    return this.http.get<User[]>(this.apiUrl);
  }

  findById(id: number): Observable<User> {
    return this.http.get<User>(`${this.apiUrl}/${id}`);
  }

  create(user: UserWithoutId): Observable<User> {
    return this.http.post<User>(`${this.apiUrl}`, user);
  }

  update(user: User): Observable<User> {
    return this.http.put<User>(`${this.apiUrl}/${user.usuario_id}`, user);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
