import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DepartamentoComponent } from './departamento/departamento.component';
import { FuncionariosComponent } from './funcionarios/funcionarios.component';
import { InicioComponent } from './inicio/inicio.component';
import { PerfilComponent } from './perfil/perfil.component';

const routes: Routes = [
  {path: '', redirectTo:'inicio', pathMatch: 'full'},
  {path: 'inicio', component: InicioComponent},
  {path: 'departamento', component: DepartamentoComponent},
  {path: 'funcionarios', component: FuncionariosComponent},
  {path: 'perfil', component: PerfilComponent},
 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
