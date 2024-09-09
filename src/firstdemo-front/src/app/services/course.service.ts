import { Injectable } from '@angular/core';
import { ICourse } from '../Data/ICourse';
import { Course } from '../Data/Course';
import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})

export class CourseService {

  private tokenUrl : string = "/v3/token";
  private dataUrl: string = "/v3/course"
  private username: string = "user@emai.com11";
  private password: string = "user@emai.com11";

  constructor(private http: HttpClient) { }

  getToken() : Observable<string>{
	let token = this.http.get(this.tokenUrl +
  	`?email=${this.username}&password=${this.password}`,
    	{
      	headers: {'Accept':'text/html, application/xhtml+xml, */*','Content-Type':'application/x-www-form-urlencoded'},
      	responseType: 'text'
    	},
  	);

	return token;
  }

  getCourses(token: string) : Observable<ICourse[]>{

	return this.http.get<ICourse[]>(this.dataUrl,
  	{
    	headers: {'Authorization':`Bearer ${token}`}
  	},
	);
  }

}


