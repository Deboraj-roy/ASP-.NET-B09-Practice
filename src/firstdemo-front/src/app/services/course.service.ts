import { Injectable } from '@angular/core';
import { ICourse } from '../Data/ICourse';
import { Course } from '../Data/Course';


@Injectable({
  providedIn: 'root'
})

export class CourseService {

  constructor() { }
  getCourses() : ICourse[]{
    return [
      new Course({ name : "C#", fees : 8000 }),
      new Course({ name : "Asp.net", fees : 30000 })
    ];
    }
  
}


