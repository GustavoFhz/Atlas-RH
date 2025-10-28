import { Component, OnInit } from '@angular/core';
import { CargoModel } from '../../../models/CargoModel/cargoModel';
import { CargoService } from '../../../services/CargoService/cargo-service';
import { ToastrService } from 'ngx-toastr';
import { RouterLink } from "@angular/router";

@Component({
  selector: 'app-home-cargo',
  imports: [RouterLink],
  templateUrl: './home-cargo.html',
  styleUrl: './home-cargo.css',
})
export class HomeCargo implements OnInit {
  cargos: CargoModel[] = [];
  cargosGeral: CargoModel[] = [];

  constructor(private cargoService: CargoService, private toastr: ToastrService) {}

  ngOnInit(): void {
    this.cargoService.BuscarCargos().subscribe((response) => {
      this.cargos = response.dados;
      this.cargosGeral = response.dados;
    });
  }
  pesquisar(value: string) {
  const val = value.toLowerCase();
  this.cargos = this.cargosGeral.filter((cargo) =>
    cargo.nome.toLowerCase().includes(val)
  );
}
  remover(id: number) {
    this.cargoService.RemoverCargo(id).subscribe((response) => {
      if (response.dados != null) {
        this.toastr.success(response.mensagem, 'Sucesso!');
        this.cargos = this.cargos.filter((cargo) => cargo.id !== id);
      } else {
        this.toastr.error(response.mensagem, 'Error!');
      }
    });
  }
}
