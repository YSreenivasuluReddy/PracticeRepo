import {AfterViewInit, Component, ViewChild,OnInit} from '@angular/core';
import { EmpService } from '../../services/emp.service';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';

@Component({
  selector: 'app-employee-details',
  standalone: true,
  imports: [MatTableModule, MatPaginatorModule],
  templateUrl: './employee-details.component.html',
  styleUrl: './employee-details.component.css'
})
export class EmployeeDetailsComponent {
constructor(private sr:EmpService){
  //this.getempdetails();
}
 @ViewChild(MatPaginator) paginator!: MatPaginator;
 displayedColumns: string[] = [
    'id',
    'name',
    'department',
    'salary'
  ];

  dataSource = new MatTableDataSource<any>([]);
 ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }
  
empdetails: any =[];

  ngOnInit(){
    this.getempdetails();
};
 getempdetails(){
  return this.sr.getEmployees().subscribe(
    {
      next: (result) => {
        console.log(result);
        this.dataSource.data = result;
        // this.empdetails = result;
      },
      error: (error) => {
        console.error('Error fetching employee details:', error);
      }
    });
  }

}
