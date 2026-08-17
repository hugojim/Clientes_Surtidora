import { Component, inject, Input, OnInit } from '@angular/core';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';

import {FormBuilder,FormGroup,ReactiveFormsModule} from '@angular/forms';

import {MatButtonModule} from '@angular/material/button';
import { ClientesService } from '../../services/clientes.service';
import { Router } from '@angular/router';
import { Cliente } from '../../models/cliente';

@Component({
  selector: 'app-cliente-formulario',
  standalone: true,

  imports: [MatFormFieldModule,MatButtonModule, MatInputModule, ReactiveFormsModule],
  templateUrl: './cliente-formulario.component.html',
  styleUrl: './cliente-formulario.component.css',
})

export class ClienteFormularioComponent  implements OnInit{
  @Input('id')clienteId!:number;
  private clientesService =inject(ClientesService);
  public formBuild = inject(FormBuilder);

  public formCliente:FormGroup = this.formBuild.group({
    Nombre:[''],
    Correo:[''],
    Telefono:['']
});


constructor(private router:Router){}

ngOnInit():void{
  this.clientesService.obtenerCliente(this.clienteId).subscribe({
    next:(data)=>{
      this.formCliente.patchValue({
         Nombre:data.nombreCompleto,
    Correo:data.correoElectronico,
    Telefono:data.telefono
      })
    },
    error:(err)=>{
      console.log(err.message);
    }
  })
}

guardarCliente(){
  const objeto:Cliente ={
    clienteId :this.clienteId,
    correoElectronico : this.formCliente.value.Correo,
telefono:this.formCliente.value.Telefono,
apellidoPaterno : this.formCliente.value.Nombre,
nombre :  this.formCliente.value.Nombre,
 nombreCompleto : this.formCliente.value.Nombre}

  if(this.clienteId == 0){
  this.clientesService.crearCliente(objeto).subscribe({
    next:(data)=>{
      if(data.isSuccess){ this.router.navigate(["/"]);}
      else{alert("Error al crear el cliente")}
     }
  })
  }
  else{
  this.clientesService.editarCliente(objeto,this.clienteId).subscribe({
    next:(data)=>{
      if(data.isSuccess){
			this.router.navigate(["/"]);
      }
      else{alert("Error al crear el cliente")}
      }
	  })
  }
}

volver()
{
	this.router.navigate(["/"]);
}
}



