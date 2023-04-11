import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private urlApi = "http://localhost/TipoCambio/getTipoCambioList";
  constructor(private http: HttpClient) {
  }
  //lista todos los tipos de cambio
  public getData(): Observable<any> {
    return this.http.get<any>(this.urlApi);
  }
  //obtiene la conversion en monedas
  public getDataTipoCambio(monto: number, monedaOrigen: string, monedaDestino:string): Observable<any> {
    const urlApiTipCambio = "http://localhost/TipoCambio/GetTipoCambio?monto="+monto+"&monedaOrigen="+monedaOrigen+"&monedaDestino="+monedaDestino;
    //console.log(urlApiTipCambio);
    return this.http.get<any>(urlApiTipCambio);
  }
}
