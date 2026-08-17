import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { Cliente } from '../models/cliente';
import { ClienteRequest } from '../models/ClienteRequest';

@Injectable({
  providedIn: 'root'
})
export class ClientesService {

  constructor() { }
  private http= inject(HttpClient);
  private URLbase = environment.apiURL + '/api/Clientes';

  public obtenerListadoClientes()
  {
    return this.http.get<any>(this.URLbase);
  }

    public obtenerCliente(id:Number)
  {
    return this.http.get<Cliente>(`${this.URLbase}/${id}`);
  }
  public crearCliente(objeto:Cliente)
  {
    console.log(objeto)
     return this.http.post<void>(this.URLbase,objeto);
  } 
public editarCliente(objeto:ClienteRequest ,id: number)
  {
     return this.http.put<void>(`${this.URLbase}/${id}`,objeto);
  } 
   public eliminarCliente(id:Number)
  {
     return this.http.delete<void>(`${this.URLbase}/${id}`);
  } 
}
