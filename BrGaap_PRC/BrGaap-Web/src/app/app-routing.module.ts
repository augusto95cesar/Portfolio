import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ClientesComponent } from './clientes/clientes.component';
import { CadastroClientesComponent } from './CadastroClientes/CadastroClientes.component';
import { EditarClientesComponent } from './EditarClientes/EditarClientes.component';


const routes: Routes = [
  {path: 'listaClientes', component: ClientesComponent },
  {path: 'cadastrarClientes', component: CadastroClientesComponent },
  {path: 'editarClientes/:cnpj', component: EditarClientesComponent },
  {path: '', redirectTo: 'listaClientes', pathMatch: 'full' },
  {path: '**', redirectTo: 'listaClientes', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
