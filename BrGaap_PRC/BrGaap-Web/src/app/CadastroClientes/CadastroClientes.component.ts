import { Component, OnInit } from '@angular/core'; 
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { stringify } from '@angular/compiler/src/util';

@Component({
  selector: 'app-CadastroClientes',
  templateUrl: './CadastroClientes.component.html'
})
export class CadastroClientesComponent implements OnInit {
  cepText: any;
  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
  }

  public SalvarCliente(){
    this.cepText = (document.getElementById('cep') as HTMLInputElement).value;
    if(this.cepText === ''){
      this.cepText = 0;
    }

    this.http.post('http://localhost:5000/api/clientes', {
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
