import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { CustomerService } from '../customer.service';
import { FormBuilder, FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Customer } from '../customer';

@Component({
  selector: 'app-customer-form',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './customer-form.component.html',
  styleUrl: './customer-form.component.css'
})
export class CustomerFormComponent implements OnInit {
  customer: Customer | undefined;

  id: number | null;
  firstName = new FormControl('', [ Validators.required ]);
  lastName = new FormControl('', [ Validators.required ]);
  email = new FormControl('', [Validators.required, Validators.email]);

  customerForm = this.formBuilder.group({
    firstName: this.firstName,
    lastName: this.lastName,
    email: this.email
  });
  constructor(private customerService: CustomerService, 
    private route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private location: Location) {
      this.id = null;
    }
  ngOnInit(): void {
    this.getCustomer();
  }

  getCustomer(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    if(idParam != null) {
      this.id = parseInt(idParam!, 10);
      this.customerService.getCustomer(this.id)
        .subscribe(c => { 
          this.customer = c;
          this.firstName.setValue(c.firstName);
          this.lastName.setValue(c.lastName); 
          this.email.setValue(c.email);
        });
    } else {
      this.id = null;
    }
  }

  onSubmit() {
    console.log(this.id);
    if(this.id != null) {
      this.customerService.updateCustomer({
        id: this.id!!,
        firstName: this.firstName.value!!,
        lastName: this.lastName.value!!,
        email: this.email.value!!,
        dateCreated: null,
        dateUpdated: null
      }).subscribe(x => this.back());
    } else {
      this.customerService.addCustomer({
        id: 0,
        firstName: this.firstName.value!!,
        lastName: this.lastName.value!!,
        email: this.email.value!!,
        dateCreated: null,
        dateUpdated: null
      }).subscribe(x => this.back());
    }
  }

  back() {
    this.location.back();
  }

}
