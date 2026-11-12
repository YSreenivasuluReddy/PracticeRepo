import { Component } from '@angular/core';
import { EmpService } from '../services/emp.service';
import { FormBuilder,Validators,ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-employee',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './add-employee.component.html',
  styleUrl: './add-employee.component.css'
})
export class AddEmployeeComponent {

  employeeForm: any;
  successMessage = '';
  errorMessage = '';

  constructor(
    private sr: EmpService,
    private fb: FormBuilder,
    private router: Router
  ) {
    this.employeeForm = this.fb.group({
      name: ['', Validators.required],
      department: ['', Validators.required],
      salary: ['', [Validators.required, Validators.min(1)]]
    });
  }

  addEmployee() {

    if (this.employeeForm.invalid) {
      this.employeeForm.markAllAsTouched();
      return;
    }

    const employee = this.employeeForm.value;
    console.log(employee);

    this.sr.addEmployee(employee).subscribe({

      next: (result) => {
        console.log('Employee added successfully:', result);

        this.successMessage = 'Employee added successfully!';
            // Redirect to Employee Details
      this.router.navigate(['/employee-details']);

        this.errorMessage = '';

        this.employeeForm.reset();
      },

      error: (error) => {
        console.error('Error adding employee:', error);

        this.errorMessage = 'Unable to add employee. Please try again.';
        this.successMessage = '';
      }

    });
  }

}
