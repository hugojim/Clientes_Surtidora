import { Component, inject } from '@angular/core';
import {MatCardModule} from '@angular/material/card';
import {MatTableModule} from '@angular/material/table';

import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import { ClientesService } from '../../services/clientes.service';
import { Router } from '@angular/router';
import { Cliente } from '../../models/cliente';

@Component({
  selector: 'app-cliente-lista',
  standalone: true,
  templateUrl: './cliente-lista.component.html',
    imports: [MatCardModule, MatButtonModule,MatTableModule,MatIconModule],
  styleUrl: './cliente-lista.component.css'
})
export class ClienteListaComponent {

 public displayedColumns : string[]=[
'ClienteId' ,'Nombre'   ,'Correo' ,'Telefono','Accion'];
 private clientesService =inject(ClientesService);
  clientes:any[] = [];  
  
obtenerClientes(){
  this.clientesService.obtenerListadoClientes().subscribe({
next:(data)=>{
  
if(data.items.length > 0){
this.clientes = data.items;
}
},
error:(err)=>{
  console.log(err.message);
}
  })
}

constructor(private router:Router) {
this.obtenerClientes();
}

nuevo(){
  this.router.navigate(['/cliente',0]);
}
editar(objeto:Cliente){

  this.router.navigate(['/cliente',objeto.clienteId]);
}

eliminar(objeto:Cliente){
// if(confirm("Desea eliminar el Cliente "+ objeto.Nombre+ " "+ objeto.ApellidoPaterno))
  
if(confirm("Desea eliminar el Cliente "))
{
  this.clientesService.eliminarCliente(objeto.clienteId).subscribe({
    next:(data)=>{
      if(data.isSuccess){
        this.obtenerClientes();
      }
      else
      {
        alert:"No se puede eliminar el cliente"
      }
    },
    error:(err)=>{
  console.log(err.message);
    }
  })
}
}
}
