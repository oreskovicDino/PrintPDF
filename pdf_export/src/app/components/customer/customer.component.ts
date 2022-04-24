import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Customer } from 'src/app/Customer';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css'],
})
export class CustomerComponent implements OnInit {
  customerId!: number;
  customer!: Customer;

  constructor(
    private route: ActivatedRoute,
    private customerService: CustomerService
    ) {}

  ngOnInit(): void {
    this.customerId = this.route.snapshot.params['id'];
    // this.customerService.getCustomer().subscribe((customers) => (this.customer = customers));
    this.customerService.getCustomer(this.customerId).subscribe((customer) => (this.customer = customer));
    
  }

}
