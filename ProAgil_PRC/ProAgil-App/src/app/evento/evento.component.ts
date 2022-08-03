import { Component, OnInit } from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-evento',
  templateUrl: './evento.component.html',
  styleUrls: ['./evento.component.css']
})
export class EventoComponent implements OnInit {

  listaEventos: any = [
    {
      EvnetoId: 1,
      Tema: 'Angular',
      Local: 'Goiania'
    },
    {
      EvnetoId: 2,
      Tema: '.Net',
      Local: 'Anapolis'
    }
  ];

  eventos: any;
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getEventos();
  }

  getEventos() {
    this.http.get('http://localhost:5000/api/values').subscribe(response => {
      this.eventos = response;
    }, error => {
      console.log(error);
    });
  }
}
