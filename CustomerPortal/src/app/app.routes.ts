import { Routes } from '@angular/router';
import { CustomersComponent } from './customers/customers/customers.component';
import { CustomerFormComponent } from './customers/customer-form/customer-form.component';

export const routes: Routes = [
    {
        path: '',
        component: CustomersComponent,
        title: 'Customers'
      },
      {
        path: 'edit/:id',
        component: CustomerFormComponent,
        title: 'Edit Customer'
      },
      {
        path: 'new',
        component: CustomerFormComponent,
        title: 'New Customer'
      }
];
