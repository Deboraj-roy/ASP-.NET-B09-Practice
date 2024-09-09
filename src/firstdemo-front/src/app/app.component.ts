import { Component, input } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ButtonComponent } from './components/button/button.component';
import { CourseComponent } from './components/course/course.component';
import { CourseService } from './services/course.service';
import { ICourse } from './Data/ICourse';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ButtonComponent, CourseComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'firstdemo-front';
 courses :ICourse[] = [];
  clickbutton1() {
    console.log("Hello, Button Clicked");
    this.update();
  }

  constructor(private courseService: CourseService){ }

  update(){
    this.courseService.getToken().subscribe((token) =>
      (
        this.courseService.getCourses(token).subscribe((data) =>
          (this.courses = data)
        )
      )
    );
  
  }

}
