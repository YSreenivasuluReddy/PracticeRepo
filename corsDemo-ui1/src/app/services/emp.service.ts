import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

//interface 

@Injectable({
  providedIn: 'root'
})
export class EmpService {

  apiurl = "https://localhost:7296/api"
  constructor(private http:HttpClient) { }
  
  //here i want to get the details from the backend.
  getEmployees(){
    return this.http.get<any[]>(`${this.apiurl}/Employee`);
    //console.log(this.apiurl);
  }

  //here i want to create the function to get details by id.

  getEmployeesById(Id:number){
    return this.http.get(`${this.http}/${Id}`)
  }

  //here i want to craete the function to add the Employee.

  addEmployee(employee:any){
    return this.http.post(`${this.apiurl}/Employee`,employee);
  }



}
