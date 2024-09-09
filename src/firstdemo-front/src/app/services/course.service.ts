import { Injectable } from '@angular/core';
import { ICourse } from '../Data/ICourse';
import { Course } from '../Data/Course';
import { Observable, of } from 'rxjs';


@Injectable({
  providedIn: 'root'
})

export class CourseService {

  constructor() { }
  getCourses() : Observable<ICourse[]>{
    return of([
      new Course({ name : "C#", fees : 8000 }),
      new Course({ name : "Asp.net", fees : 30000 })
    ]);
    }
  
  getCourses2() : ICourse[]{
    return [
      new Course({ name : "C#", fees : 8000 }),
      new Course({ name : "Asp.net", fees : 30000 })
    ];
    }
  
}


