import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html'
})
export class ClientesComponent implements OnInit {

  listaClientes: any;

  constructor( private http: HttpClient ) { }

  ngOnInit() {
    this.getClientes();
  }

  getClientes() {
    this.http.get('http://localhost:5000/api/clientes/GetClientes').subscribe( response =>
    {
      this.listaClientes = response;
     // console.log(this.listaClientes);
    },
      error => {console.log(error);
    });
  }

  deletarCliente(id){
    //alert("Cliente Deletado: " + id);
    this.http.delete('http://localhost:5000/api/clientes/' + id).subscribe(response => {
      document.location.reload(true);
    }, error => {
      console.log(error);
    });

  }

}
