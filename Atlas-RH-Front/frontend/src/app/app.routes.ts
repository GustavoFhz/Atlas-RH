import { Routes } from '@angular/router';

import { Home } from './pages/Usuario/home-usuario/home';
import { Detalhes } from './pages/Usuario/detalhes-usuario/detalhes-usuario';
import { Editar } from './pages/Usuario/editar-usuario/editar-usuario';
import { Login } from './pages/login/login';
import { authGuard } from './guards/auth-guard';
import { Layout } from './pages/layout/layout';
import { Inicio } from './pages/inicio/inicio';
import { HomeCargo } from './pages/Cargo/home-cargo/home-cargo';
import { DetalhesCargo } from './pages/Cargo/detalhes-cargo/detalhes-cargo';
import { EditarCargo } from './pages/Cargo/editar-cargo/editar-cargo';
import { CadastrarCargo } from './pages/Cargo/cadastrar-cargo/cadastrar-cargo';
import { HomeFuncionario } from './pages/funcionario/home-funcionario/home-funcionario';
import { DetalhesFuncionario } from './pages/funcionario/detalhes-funcionario/detalhes-funcionario';
import { EditarFuncionario } from './pages/funcionario/editar-funcionario/editar-funcionario';
import { CadastrarFuncionario } from './pages/funcionario/cadastrar-funcionario/cadastrar-funcionario';
import { HomeDepartamento } from './pages/Departamento/home-departamento/home-departamento';
import { DetalhesDepartamento } from './pages/Departamento/detalhes-departamento/detalhes-departamento';
import { EditarDepartamento } from './pages/Departamento/editar-departamento/editar-departamento';
import { CadastrarDepartamento } from './pages/Departamento/cadastrar-departamento/cadastrar-departamento';
import { CadastrarUsuario } from './pages/Usuario/cadastrar-usuario/cadastrar-usuario';

export const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: Login },

  {
    path: '',
    component: Layout,
    canActivate: [authGuard],
    canActivateChild: [authGuard],
    children: [
      { path: 'inicio', component: Inicio },

      { path: 'homeUsuario', component: Home },
      { path: 'detalhes-usuario/:id', component: Detalhes },
      { path: 'editar-usuario/:id', component: Editar },
      {path: 'cadastro-usuario', component:CadastrarUsuario},

      { path: 'homeCargo', component: HomeCargo },
      { path: 'detalhes-cargo/:id', component: DetalhesCargo },
      { path: 'editar-cargo/:id', component: EditarCargo },
      { path: 'cadastro-cargo', component: CadastrarCargo },

      { path: 'homeFuncionario', component: HomeFuncionario },
      { path: 'detalhes-funcionario/:id', component: DetalhesFuncionario },
      { path: 'editar-funcionario/:id', component: EditarFuncionario },
      { path: 'cadastro-funcionario', component: CadastrarFuncionario },

      { path: 'homeDepartamento', component: HomeDepartamento },
      { path: 'detalhes-departamento/:id', component: DetalhesDepartamento },
      { path: 'editar-departamento/:id', component: EditarDepartamento },
      { path: 'cadastro-departamento', component: CadastrarDepartamento },
    ],
  },

  { path: '**', redirectTo: 'login' },
];
