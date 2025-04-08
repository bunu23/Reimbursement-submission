import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

describe('AppComponent', () => {
  let component: AppComponent;
  let fixture: ComponentFixture<AppComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AppComponent, CommonModule, HttpClientTestingModule, FormsModule]
    }).compileComponents();

    fixture = TestBed.createComponent(AppComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create the app component', () => {
    expect(component).toBeTruthy();
  });

  it('should have empty receipt list initially', () => {
    expect(component.receipts).toEqual([]);
  });

  it('should reset the form after submit', () => {
    component.purchaseDate = '2024-04-01';
    component.amount = 100;
    component.description = 'Test';
    component.resetForm();
    expect(component.purchaseDate).toBe('');
    expect(component.amount).toBe(0);
    expect(component.description).toBe('');
  });

  
});
