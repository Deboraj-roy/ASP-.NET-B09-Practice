import { Component, Input, input } from '@angular/core';

@Component({
  selector: 'app-button',
  standalone: true,
  imports: [],
  templateUrl: './button.component.html',
  styleUrl: './button.component.css'
})
export class ButtonComponent {
@Input() text:string = "Press!";
@Input() color:string = "blue";
/**
 *
 */
constructor() {}
ngOnInit(): void{

}
}
