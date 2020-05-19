import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { HomeComponent } from './home.component';
import { FormsModule } from '@angular/forms';
import { InjectionToken } from '@angular/core';
export const BASE_URL = new InjectionToken<string>('BASE_URL');
describe('HomeComponent', () => {
  let component: HomeComponent;
  let fixture: ComponentFixture<HomeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HomeComponent ],
      imports: [FormsModule,HttpClientTestingModule],
      providers:[{ provide: "BASE_URL", useValue: 'http://localhost' }]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });
  
  it('should display a title', async(() => {
    const titleText = fixture.nativeElement.querySelector('h2').textContent;
    expect(titleText).toEqual('String Comparer');
  }));

  it('should disable Get Index of Inputtext button, if input text is empty', async(() => {
    const subTextElement = fixture.nativeElement.querySelector('#subText');
    const inputTextElement = fixture.nativeElement.querySelector('#inputText');
    expect(subTextElement.textContent).toEqual('');
    inputTextElement.textContent='';
    subTextElement.textContent='123';
 
    const comparebutton = fixture.nativeElement.querySelector('#submitBtn');
 
    //check if it is disabled
   expect(comparebutton.disabled).toBeTruthy();
  }));

 it('should disable Get Index of Subtext button, if sub text is empty', async(() => {
   const subTextElement = fixture.nativeElement.querySelector('#subText');
   const inputTextElement = fixture.nativeElement.querySelector('#inputText');
   expect(subTextElement.textContent).toEqual('');
   inputTextElement.textContent='123';
   subTextElement.textContent='';

   //const comparebutton = fixture.nativeElement.querySelector('#submitBtn');
   expect(fixture.nativeElement.querySelector('#submitBtn').disabled).toBeTruthy();
   //check if it is disabled
   //expect(comparebutton.disabled).toBeTruthy();
 }));
 

  //Error div displayed test
  //success div displayed test


});
