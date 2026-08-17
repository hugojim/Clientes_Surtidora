import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { Cliente } from '../models/cliente';
import { ResponseAPI } from '../models/ResponseAPI';

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
     return this.http.post<ResponseAPI>(this.URLbase,objeto);
  } 
public editarCliente(objeto:Cliente,id: number)
  {
     return this.http.put<ResponseAPI>(`${this.URLbase}/${id}`,objeto);
  } 
   public eliminarCliente(id:Number)
  {
     return this.http.delete<ResponseAPI>(`${this.URLbase}/${id}`);
  } 
}
