import { Component, OnInit } from '@angular/core';
import {MatListModule} from '@angular/material/list';
import { CustomerService } from '../customer.service';
import { Customer } from '../customer';

@Component({
  selector: 'app-customers',
  standalone: true,
  imports: [MatListModule],
  templateUrl: './customers.component.html',
  styleUrl: './customers.component.css'
})
export class CustomersComponent implements OnInit {

  customers: Customer[] = [];
  constructor(private customerService: CustomerService) {}

  ngOnInit(): void {
    this.getCustomers();
  }

  getCustomers(): void {
    this.customerService.getCustomers().subscribe(c => this.customers = c);
  }

}
