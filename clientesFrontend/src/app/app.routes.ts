import { Routes } from '@angular/router';
import { ClienteFormularioComponent } from './clientes/components/cliente-formulario/cliente-formulario.component';
import { ClienteListaComponent } from './clientes/components/cliente-lista/cliente-lista.component';


export const routes: Routes = [
    {path:'',component:ClienteListaComponent},
    {path:'inicio',component:ClienteListaComponent},
      {path:'cliente/:id',component:ClienteFormularioComponent},
];