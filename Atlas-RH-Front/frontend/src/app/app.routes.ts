import { Routes } from '@angular/router';

import { Home } from './pages/Usuario/home/home';
import { Detalhes } from './pages/Usuario/detalhes/detalhes';
import { Editar } from './pages/Usuario/editar/editar';
import { Cadastrar } from './pages/Usuario/cadastrar/cadastrar';
import { Login } from './pages/login/login';
import { authGuard } from './guards/auth-guard';
import { Layout } from './pages/layout/layout';
import { Inicio } from './pages/inicio/inicio';
import { HomeCargo } from './pages/Cargo/home-cargo/home-cargo';
import { DetalhesCargo } from './pages/Cargo/detalhes-cargo/detalhes-cargo';
import { EditarCargo } from './pages/Cargo/editar-cargo/editar-cargo';
import { CadastrarCargo } from './pages/Cargo/cadastrar-cargo/cadastrar-cargo';

export const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: Login },
  { path: 'cadastro', component: Cadastrar }, // fora do authGuard

  {
    path: '',
    component: Layout,
    canActivateChild: [authGuard], // protege todas as rotas filhas
    children: [
      { path: 'inicio', component: Inicio },

      { path: 'home', component: Home },
      { path: 'detalhes/:id', component: Detalhes },
      { path: 'editar/:id', component: Editar },

      { path: 'homeCargo', component: HomeCargo },
      { path: 'detalhes-cargo/:id', component: DetalhesCargo },
      { path: 'editar-cargo/:id', component: EditarCargo },
      {path: 'cadastro-cargo', component: CadastrarCargo},
    ],
  },

  { path: '**', redirectTo: 'login' },
];
