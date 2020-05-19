import { Component,Inject } from '@angular/core';
import { HttpParams,HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  inputText:string;
  subText:string;
  compareResult:CompareResult={};
  baseUrl:string
  http: HttpClient
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string){
  this.baseUrl = baseUrl;  
  this.http = http;
  }

  public getIndexOfSubtext() {
    this.compareResult.Description = "Processing...";
    this.compareResult.IsValid = null;

    this.compareResult.QueryText = this.inputText.trim();
    this.compareResult.QuerySubText = this.subText.trim();

    let params = new HttpParams();
    params = params.append('inputText', this.compareResult.QueryText);
    params = params.append('subText', this.compareResult.QuerySubText);

    this.http.get<CompareResult>(this.baseUrl + 'stringcomparer',{params: params})
    .toPromise()
    .then((result:any) => {
      this.compareResult.IsValid = result.isValid;
      this.compareResult.Description = result.description.join();
    })
    .catch(error=>
      {
        this.compareResult.Description="Unknown error: Please contact admin";
        this.compareResult.IsValid = false;
        console.log (error);
      });
  }

}

interface CompareResult {
  IsValid?: boolean;
  Description?: string;
  QueryText?: string;
  QuerySubText?:string;
}