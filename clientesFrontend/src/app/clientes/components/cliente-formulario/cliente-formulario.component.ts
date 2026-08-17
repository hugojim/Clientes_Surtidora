import { Component, inject, Input, OnInit } from '@angular/core';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';

import {MatCardModule} from '@angular/material/card';
import {FormBuilder,FormGroup,ReactiveFormsModule,Validators} from '@angular/forms';

import {MatIconModule} from '@angular/material/icon';
import {MatDividerModule} from '@angular/material/divider';
import {MatButtonModule} from '@angular/material/button';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import { ClientesService } from '../../services/clientes.service';
import { Router } from '@angular/router';
import { Cliente } from '../../models/cliente';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';

@Component({
  selector: 'app-cliente-formulario',
  standalone: true,

  imports: [MatFormFieldModule,MatButtonModule,MatDatepickerModule,
    MatSlideToggleModule,MatIconModule,MatDividerModule,MatNativeDateModule,
    MatInputModule, MatCardModule,ReactiveFormsModule],
  templateUrl: './cliente-formulario.component.html',
  styleUrl: './cliente-formulario.component.css',
})

export class ClienteFormularioComponent  implements OnInit{
  @Input('id')clienteId!:number;
  private clientesService =inject(ClientesService);
  public formBuild = inject(FormBuilder);

  public formCliente:FormGroup = this.formBuild.group({
    nombre:['',Validators.required],
 apellidoPaterno :['',Validators.required], 
apellidoMaterno:[''],
correoElectronico  :['',[Validators.required, Validators.email]], 
telefono :[''],
fechaNacimiento :[null],
direccion :[''],
ciudad  :[''],
codigoPostal :[''],
activo :[''],
fechaRegistro :[null],
fechaModificacion :[null],
nombreCompleto:[''],
});


constructor(private router:Router){}

ngOnInit():void{
  if(this.clienteId > 0){
  this.clientesService.obtenerCliente(this.clienteId).subscribe({
    next:(data)=>{
      this.formCliente.patchValue({
         nombre:data.nombre,
    correoElectronico:data.correoElectronico,
    telefono:data.telefono,
apellidoPaterno : data.apellidoPaterno,
activo :data.activo,
ciudad: data.ciudad,
apellidoMaterno:data.apellidoMaterno,
codigoPostal:data.codigoPostal
,direccion:data.direccion,
fechaModificacion:data.fechaModificacion,
fechaNacimiento: data.fechaNacimiento,
fechaRegistro: data.fechaRegistro,
nombreCompleto:data.nombreCompleto
      })
    },
    error:(err)=>{
      console.log(err.message);
    }
  })
}
else
{
  this.formCliente.patchValue({
  fechaRegistro: new Date().toISOString()
});
}

}

guardarCliente(){

   if (this.formCliente.invalid) {

    // Hace que Angular muestre los errores
    this.formCliente.markAllAsTouched();

    return;
  }
  const objeto:Cliente ={
    clienteId :this.clienteId,
    nombre :  this.formCliente.value.nombre,    
apellidoPaterno : this.formCliente.value.apellidoPaterno,
apellidoMaterno:this.formCliente.value.apellidoMaterno,
    correoElectronico : this.formCliente.value.correoElectronico,
telefono:this.formCliente.value.telefono,
activo :this.formCliente.value.activo,
ciudad: this.formCliente.value.ciudad,
codigoPostal:this.formCliente.value.codigoPostal,
direccion:this.formCliente.value.direccion,
fechaModificacion:this.formCliente.value.fechaModificacion,
//  fechaNacimiento: this.formCliente.value.fechaNacimiento,
       fechaNacimiento: this.formCliente.value.fechaNacimiento ? this.formCliente.value.fechaNacimiento.toISOString().substring(0, 10)
       : null ,
       fechaRegistro:this.formCliente.value.fechaRegistro,
nombreCompleto:this.formCliente.value.nombreCompleto

}
console.log(objeto.fechaNacimiento)
console.log(objeto)
  if(this.clienteId == 0){
  this.clientesService.crearCliente(objeto).subscribe({
    next:(data)=>{
      console.log(data)
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

private formatDate(date: Date): string {

  const year = date.getFullYear();
  const month = String(date.getMonth() + 1).padStart(2, '0');
  const day = String(date.getDate()).padStart(2, '0');

  return `${year}-${month}-${day}`;
}

formatFecha(fecha: string | null): string {

  if (!fecha) {
    return '';
  }

  const fechaCorta = fecha.substring(0, 10);

  const [anio, mes, dia] = fechaCorta.split('-');

  return `${dia}/${mes}/${anio}`;
}
}



