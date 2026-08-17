import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ClientesService } from './clientes/services/clientes.service';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
clientesService = inject(ClientesService);

  clientes:any[] = [];  

  
constructor(){
  this.clientesService.obtenerListadoClientes().subscribe(datos =>{
this.clientes = datos.items;
  });
 }
}
