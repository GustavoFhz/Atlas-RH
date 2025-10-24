import { Component } from '@angular/core';
import { CargoService } from '../../../services/CargoService/cargo-service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { FormularioCargo } from '../../../componentes/formulario-cargo/formulario-cargo';
import { CargoCriacaoDto } from '../../../models/CargoModel/cargoCriacaoDto';

@Component({
  selector: 'app-cadastrar-cargo',
  imports: [FormularioCargo],
  templateUrl: './cadastrar-cargo.html',
  styleUrl: './cadastrar-cargo.css'
})
export class CadastrarCargo {

  btnAcao = 'Cadastrar';
  descTitulo = 'Cadastrar Cargos';

  constructor(
    private cargoService: CargoService,
    private router: Router,
    private toastr: ToastrService
  ) {}

  criarCargo(cargo: CargoCriacaoDto) {
    console.log('Chamando serviço para criar cargo:', cargo);

    this.cargoService.registrarCargo(cargo).subscribe({
      next: (response) => {
        if (response.dados != null) {
          this.toastr.success(response.mensagem, 'Sucesso!');
          this.router.navigate(['/homeCargo']); 
        } else {
          this.toastr.error(response.mensagem, 'Erro!');
        }
      },
      error: (err) => {
        console.error('Erro ao cadastrar cargo:', err);
        this.toastr.error('Erro ao cadastrar cargo. Verifique os dados.', 'Erro!');
      }
    });
  }
}
