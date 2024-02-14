import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Customer } from './customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  private customerUrl = 'customer';  // URL to web api

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  
  constructor(private http: HttpClient) { }

  getCustomers(): Observable<Customer[]> {
    return this.http.get<Customer[]>(this.customerUrl, this.httpOptions);
  }

  getCustomer(id: number) {
    return this.http.get<Customer>(this.customerUrl + '/' + id, this.httpOptions);
  }

  addCustomer(customer: Customer): Observable<Customer> {
    return this.http.post<Customer>(this.customerUrl, customer, this.httpOptions);
  }

  updateCustomer(customer: Customer) {
    return this.http.put(this.customerUrl, customer, this.httpOptions);
  }
  
  deleteCustomer(id: number) {
    return this.http.delete(this.customerUrl + '/' + id, this.httpOptions);
  }


}
