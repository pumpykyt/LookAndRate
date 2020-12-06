import { Injectable } from '@angular/core';
import { ApiResult } from './../../../Models/result.model';
import { ActorModel } from './../../../Models/actor.model'
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ActorService {

  baseUrl = '/api/Actor';
  constructor(private http: HttpClient) { }

  getAllActor(){
    return this.http.get(this.baseUrl)
  }

  getActor(id: number){
    return this.http.get(this.baseUrl + '/get/' + id);
  }

  addActor(model : ActorModel){
    return this.http.post<ApiResult>(this.baseUrl + '/addactor/' , model);
  }

}
