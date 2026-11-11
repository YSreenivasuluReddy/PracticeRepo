import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { EmployeeDetailsComponent } from './components/employee-details/employee-details.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,EmployeeDetailsComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'corsDemo-ui1';
}
