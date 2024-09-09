import { ICourse } from "./ICourse";

export class Course implements ICourse{
	public title : string = "";
	public description : string = "";
	public fees : number = 0;

      // constructor syntax to easily initialize current object
	public constructor(init?:Partial<Course>) {
    	   Object.assign(this, init);
	}
} 
