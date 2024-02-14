import { Component, Inject, OnInit } from '@angular/core';
import {MatListModule} from '@angular/material/list';
import { CustomerService } from '../customer.service';
import { Customer } from '../customer';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-customers',
  standalone: true,
  imports: [CommonModule, MatListModule],
  templateUrl: './customers.component.html',
  styleUrl: './customers.component.css'
})
export class CustomersComponent implements OnInit {

  private _selectionSessionKey = 'selectedCustomerId';
  customers: Customer[] = [];
  selectedCustomer: Customer | undefined;
  constructor(private customerService: CustomerService,
    private route: ActivatedRoute,
    private router: Router) {
    this.selectedCustomer = undefined;
  }

  ngOnInit(): void {
    this.getCustomers();
  }

  getCustomers(): void {
    this.customerService.getCustomers().subscribe(c => {
      this.customers = c;
      const selectedCustomerId = sessionStorage.getItem(this._selectionSessionKey);
      if(selectedCustomerId != null) {
        const id = parseInt(selectedCustomerId!, 10);
        this.selectedCustomer = this.customers.find(x => x.id == id);
      }
    });
  }

  selectCustomer(customer: Customer): void {
    this.selectedCustomer = customer;
    sessionStorage.setItem(this._selectionSessionKey, customer.id.toString());
  }

  deleteCustomer(customer: Customer): void {
    if(customer == this.selectedCustomer) {
      this.selectedCustomer = undefined;
      sessionStorage.removeItem(this._selectionSessionKey);
    }

    this.customerService.deleteCustomer(customer.id)
      .subscribe(x => { 
        //Removed the deleted customer from the list
        const index = this.customers.indexOf(customer, 0);
        if (index > -1) {
          this.customers.splice(index, 1);
        }});
  }

  editCustomer(customer: Customer): void {
    this.router.navigate([`edit/${customer.id}`]);
  }

  addCustomer(): void {
    
    this.router.navigate([`new`]);
  }
}
