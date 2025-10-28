import { Component } from '@angular/core';
import { FormularioDepartamento } from '../../../componentes/formulario-departamento/formulario-departamento';
import { DepartamentoService } from '../../../services/DepartamentoService/departamento-service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DepartamentoCriacoDto } from '../../../models/Departamento/departamentoCriacaoDto';

@Component({
  selector: 'app-cadastrar-departamento',
  imports: [FormularioDepartamento],
  templateUrl: './cadastrar-departamento.html',
  styleUrl: './cadastrar-departamento.css'
})
export class CadastrarDepartamento {
   btnAcao = 'Cadastrar';
  descTitulo = 'Cadastrar Departamentos';

  constructor(
    private departamentoService: DepartamentoService,
    private router: Router,
    private toastr: ToastrService
  ) {}

  criarDepartamento(departamento: DepartamentoCriacoDto) {
    console.log('Chamando serviço para criar departamento:', departamento);

    this.departamentoService.RegistrarDepartamento(departamento).subscribe({
      next: (response) => {
        if (response.dados != null) {
          this.toastr.success(response.mensagem, 'Sucesso!');
          this.router.navigate(['/homeDepartamento']); 
        } else {
          this.toastr.error(response.mensagem, 'Erro!');
        }
      },
      error: (err) => {
        console.error('Erro ao cadastrar departamento:', err);
        this.toastr.error('Erro ao cadastrar departamento. Verifique os dados.', 'Erro!');
      }
    });
  }
  }
