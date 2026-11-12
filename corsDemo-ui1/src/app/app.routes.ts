import { Routes } from '@angular/router';
import { EmployeeDetailsComponent } from './components/employee-details/employee-details.component';
import { AddEmployeeComponent } from './components/add-employee.component';

export const routes: Routes = [
    {path:'',redirectTo:'add-employee',pathMatch:'full'},
    {path:'add-employee',component:AddEmployeeComponent},
    {path:'employee-details',component:EmployeeDetailsComponent}
];
