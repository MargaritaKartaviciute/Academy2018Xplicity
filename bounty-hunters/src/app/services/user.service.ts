import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../Models/user';
import { environment } from '../../environments/environment';

@Injectable(
  {
    providedIn: 'root'
  }
)
export class UserService {
    private readonly authApi = `${environment.webApiUrl}/auth`;

    constructor(private http: HttpClient) { }

     getAll() {
        return this.http.get<User[]>(`/users`);
    }

    getById(id: number) {
        return this.http.get(`/users/` + id);
    }

    register(user: User) {
        return this.http.post(this.authApi + '/register', user);
    }

    update(user: User) {
        return this.http.put(`/users/` + user.id, user);
    }

    delete(id: number) {
        return this.http.delete(`/users/` + id);
    }
}
