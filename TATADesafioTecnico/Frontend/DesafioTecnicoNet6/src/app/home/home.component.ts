import { Component,  OnInit } from '@angular/core';
import { Console } from 'console';
import { ApiService } from '../service/api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  mostrarResult: boolean = false;

  Monto: any = '';
  MonedaOri: any = '';
  MonedaDes: any = '';

  TipoCambio: any = '';
  MontoCambio: any ;

  data: any[] = [];

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.inicializarData();
  }

  inicializarData() {
    this.apiService.getData().subscribe(data => {
      this.data = data;
    })
  }

  CalcularTipoCambio() {
    console.log(this.Monto, this.MonedaOri, this.MonedaDes);
    this.apiService.getDataTipoCambio(this.Monto, this.MonedaOri, this.MonedaDes).subscribe(data => {
      this.Monto = data.monto;
      this.MontoCambio = data.montoTipoCambio;
      this.MonedaOri = data.monedaOrigen;
      this.MonedaDes = data.monedaDestino;
      this.TipoCambio = data.tipoCambio;
    })
    this.mostrarResult = true;
  }


}
