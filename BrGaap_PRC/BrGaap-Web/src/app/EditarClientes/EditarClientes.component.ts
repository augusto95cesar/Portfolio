import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router'; 
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-EditarClientes',
  templateUrl: './EditarClientes.component.html'
 
})
export class EditarClientesComponent implements OnInit {
  cnpj:any;
  cliente: any;
  cepText: any;

  constructor(private route: ActivatedRoute, private http: HttpClient, private router: Router ) { }

  ngOnInit() {
    this.route.params.subscribe(result => {
      this.cnpj = result['cnpj'];
      //console.log(this.cnpj);
      this.getClienteCnpj();
    })
  }

  getClienteCnpj(){
    this.http.get('http://localhost:5000/api/clientes/' + this.cnpj).subscribe(response => {
      this.cliente = response;
      //console.log("Clientes" + this.cliente.nomeCliente);
    }, error => {
      console.log(error);
    });
  }

  EditarCliente(){
    // alert("Editar Cliente");
     this.cepText = (document.getElementById('cep') as HTMLInputElement).value;
     if(this.cepText === ''){
       this.cepText = 0;
     }
 
     this.http.put('http://localhost:5000/api/clientes/' + this.cliente.id, {
       "id":this.cliente.id,
       "nomeCliente": (document.getElementById('nome') as HTMLInputElement).value,
       "cnpj": (document.getElementById('cnpj') as HTMLInputElement).value,
       "cep": this.cepText,
       "bairro": (document.getElementById('bairro') as HTMLInputElement).value,
       "cidade": (document.getElementById('cidade') as HTMLInputElement).value,
       "estado": (document.getElementById('estado') as HTMLInputElement).value,
       "logradouro": (document.getElementById('logradouro') as HTMLInputElement).value
     }).subscribe( response =>
     {
       console.log(response);
 
       if(response === true){
          this.router.navigate(['/']);
       }else{
         alert("Cnpj Existente");
         (document.getElementById('cnpj') as HTMLInputElement).value =  '';
       }
     },
       error => {console.log(error);
     });
  }

}
