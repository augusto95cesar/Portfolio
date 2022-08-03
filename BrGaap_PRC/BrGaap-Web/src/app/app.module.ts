import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ClientesComponent } from './clientes/clientes.component';
import { CadastroClientesComponent } from './CadastroClientes/CadastroClientes.component';
import { EditarClientesComponent } from './EditarClientes/EditarClientes.component';

@NgModule({
   declarations: [
      AppComponent,
      ClientesComponent,
      CadastroClientesComponent,
      EditarClientesComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
