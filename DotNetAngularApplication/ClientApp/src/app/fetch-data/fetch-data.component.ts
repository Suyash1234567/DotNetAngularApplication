import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent
{
  searchName: string = "";
  public forecasts: GetStudent[];
  baseUrl: string

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {
    http.get<GetStudent[]>(baseUrl + 'api/SampleData/GetStudent').subscribe(result =>
    {
      this.forecasts = result;
      console.log(result,"hi");
    }, error => console.error(error));
    
    
  }
  sendMessage() {


    var student = {
      name: "John"

    };

    //var st = this.searchName;
    //student.name =  this.searchName;
    var Student = JSON.stringify(student);
    //var httpOptions = {
    //  headers: new HttpHeaders({                  
    //    'Content-Type': 'application/json;charset=utf-8'
    //  })
    //};
    
    //this.http.post<GetStudent[]>('api/SampleData/SearchByName?student=searchName', "student": "Ram").subscribe(result => {
    //this.http.post<GetStudent[]>('api/SampleData/SearchByName', 'data:' + Student, httpOptions).subscribe(result => {
    this.http.get<GetStudent[]>('api/SampleData/SearchByName?student='+this.searchName).subscribe(result => {
      this.forecasts = result;
    //var student = 'Ram'
    //this.http.get<GetStudent[]>('api/SampleData/SearchByName?student=searchName').subscribe(result => {
    //  this.forecasts = result;
      console.log(this.searchName);
      console.log(this.forecasts, "heyyyy");
    }, error => console.error(error));
  }
}


interface GetStudent {
  StudentId: number;
  StudentName: string;
  StudentClass: number;
  StudentAge: number;
  StudentFees: number;
  Date: Date;
}




