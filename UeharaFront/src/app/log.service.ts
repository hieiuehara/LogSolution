import {Injectable} from "@angular/core";
import {Observable} from "rxjs";
import { HttpClient } from '@angular/common/http';
import { Http } from '@angular/http';
import {Log, LogRespondeModel} from "./models/log";

@Injectable()
export class ApiService {
    constructor(private http: Http) {}
  public getUsers(): Observable<Log[]> {
    let fakeUsers : Log[] = [{position: 1, firstName: 'Dhiraj', lastName: 'Ray', email: 'dhiraj@gmail.com'},
      {position: 2, firstName: 'Tom', lastName: 'Jac', email: 'Tom@gmail.com'},
      {position: 3, firstName: 'Hary', lastName: 'Pan', email: 'hary@gmail.com'},
      {position: 4, firstName: 'praks', lastName: 'pb', email: 'praks@gmail.com'},
    ];
    return Observable.create( observer => {
        observer.next(fakeUsers);
        observer.complete();
    });
  }
  getAll() {
    return this.http.get('https://localhost:5001/api/log?pagesize=10')
    .toPromise()
    .then(response => {
        console.log(response.json(), "json")
        return response.json() as LogRespondeModel[]}
    );
  }
}
