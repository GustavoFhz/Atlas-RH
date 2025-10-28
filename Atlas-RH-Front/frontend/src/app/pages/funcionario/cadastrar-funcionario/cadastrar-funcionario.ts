import { Component } from '@angular/core';
import { FormularioFuncionario } from '../../../componentes/formulario-funcionario/formulario-funcionario';
import { FuncionarioService } from '../../../services/FuncionarioService/funcionario-service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { FuncionarioCriacaoDto } from '../../../models/FuncionarioModel/funcionarioCricaoDto';

@Component({
  selector: 'app-cadastrar-funcionario',
  imports: [FormularioFuncionario],
  templateUrl: './cadastrar-funcionario.html',
  styleUrl: './cadastrar-funcionario.css',
})
export class CadastrarFuncionario {
  btnAcao = 'Cadastrar';
  descTitulo = 'Cadastrar Funcionário';

  constructor(
    private funcionarioService: FuncionarioService,
    private router: Router,
    private toastr: ToastrService
  ) {}

  criarFuncionario(funcionario: FuncionarioCriacaoDto) {
    console.log('Chamando serviço para criar funcionario:', funcionario);

    this.funcionarioService.RegistrarFuncionario(funcionario).subscribe({
      next: (response) => {
        if (response.dados != null) {
          this.toastr.success(response.mensagem, 'Sucesso!');
          this.router.navigate(['/homeFuncionario']);
        } else {
          this.toastr.error(response.mensagem, 'Erro!');
        }
      },
      error: (err) => {
        console.error('Erro ao cadastrar funcionário:', err);
        this.toastr.error('Erro ao cadastrar funcionário. Verifique os dados.', 'Erro!');
      },
    });
  }
}
