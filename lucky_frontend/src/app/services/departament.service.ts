import { Injectable } from '@angular/core';
import { Departamento } from '../models/departament';
import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
  })

  export class DepartamentService {
    private apiUrl='https://localhost:7295/Departamento';
    private departaments: Departamento[] = [];
    constructor(private http:HttpClient) { }
  
    findAll(): Observable<Departamento[]> {
      return this.http.get<Departamento[]>(this.apiUrl);
    }
  
    findById(id: number): Observable<Departamento> {
      return this.http.get<Departamento>(`${this.apiUrl}/${id}`);
    }
  
    create(departamento: Departamento): Observable<Departamento> {
      return this.http.post<Departamento>(`${this.apiUrl}`, departamento);
    }
  
    update(departamento: Departamento): Observable<Departamento> {
      return this.http.put<Departamento>(`${this.apiUrl}/${departamento.departamento_id}`, departamento);
    }
  
    delete(id: number): Observable<void> {
      return this.http.delete<void>(`${this.apiUrl}/${id}`);
    }
}