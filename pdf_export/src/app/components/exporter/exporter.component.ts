import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import jsPDF from 'jspdf';
import html2canvas from 'html2canvas';
import { Customer } from 'src/app/Customer';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-exporter',
  templateUrl: './exporter.component.html',
  styleUrls: ['./exporter.component.css'],
})
export class ExporterComponent implements OnInit {
  @ViewChild('pdf_content') content!: ElementRef;
  fileName!: string;
  customers!: Customer[];

  constructor(private customerService: CustomerService) {}

  ngOnInit(): void {
    this.customerService
      .getCustomers()
      .subscribe((customers: Customer[]) => (this.customers = customers));
  }

  onSubmit() {
    this.openPDF();
  }

  public openPDF(): void { 
    let DATA: any = document.getElementById('customer-table');
    html2canvas(DATA).then((canvas) => {
      let fileWidth = 208;
      let fileHeight = (canvas.height * fileWidth) / canvas.width;
      const FILEURI = canvas.toDataURL('image/png');
      let PDF = new jsPDF('p', 'mm', 'a4');
      let position = 0;
      PDF.addImage(FILEURI, 'PNG', 0, position, fileWidth, fileHeight);
      PDF.save(this.fileName + '.pdf');
    });
  }
}
