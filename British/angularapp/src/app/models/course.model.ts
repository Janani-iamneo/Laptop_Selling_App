import { Enquiry } from "./enquiry.model";
import { Student } from "./student.model";

export interface Course {
  courseID: number;
  courseName: string;
  description: string;
  duration: string;
  amount: number;
  enquiries?: Enquiry[];
  students?: Student[];
}



// export interface Course {
//     courseID: number;
//     courseName: string;
//     description: string;
//     duration: string;
//     amount: number;
//   }
  

