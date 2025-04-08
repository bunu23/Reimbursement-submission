import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';

export interface Receipt {
  id: number;
  purchaseDate: string;
  amount: number;
  description: string;
  receiptFilePath?: string;
}

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule
  ],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  purchaseDate: string = '';
  amount: number = 0;
  description: string = '';
  selectedFile: File | null = null;
  receipts: Receipt[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.loadReceipts();
  }

  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0];
  }

  onSubmit() {
    const formData = new FormData();
    formData.append('purchaseDate', this.purchaseDate);
    formData.append('amount', this.amount.toString());
    formData.append('description', this.description);
    if (this.selectedFile) {
      formData.append('receiptFile', this.selectedFile);
    }

    this.http.post<Receipt>('https://localhost:7093/api/receipt', formData)
      .subscribe(() => {
        this.resetForm();
        this.loadReceipts();
      });
  }

  loadReceipts() {
    this.http.get<Receipt[]>('https://localhost:7093/api/receipt')
      .subscribe(data => {
        this.receipts = data;
      });
  }

  resetForm() {
    this.purchaseDate = '';
    this.amount = 0;
    this.description = '';
    this.selectedFile = null;
  }
}
