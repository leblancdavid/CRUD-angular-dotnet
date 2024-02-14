import { Component, OnInit } from '@angular/core';
import {MatListModule} from '@angular/material/list';
import { CustomerService } from '../customer.service';
import { Customer } from '../customer';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-customers',
  standalone: true,
  imports: [CommonModule, MatListModule],
  templateUrl: './customers.component.html',
  styleUrl: './customers.component.css'
})
export class CustomersComponent implements OnInit {

  customers: Customer[] = [];
  selectedCustomer: Customer | null;
  constructor(private customerService: CustomerService) {
    this.selectedCustomer = null;
  }

  ngOnInit(): void {
    this.getCustomers();
  }

  getCustomers(): void {
    this.customerService.getCustomers().subscribe(c => this.customers = c);
  }

  selectCustomer(customer: Customer): void {
    this.selectedCustomer = customer;
  }

  deleteCustomer(customer: Customer): void {
    if(customer == this.selectedCustomer) {
      this.selectedCustomer = null;
    }

    this.customerService.deleteCustomer(customer.id)
      .subscribe(x => { 
        //Removed the deleted customer from the list
        const index = this.customers.indexOf(customer, 0);
        if (index > -1) {
          this.customers.splice(index, 1);
        }});
  }
}
