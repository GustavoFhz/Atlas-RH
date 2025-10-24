import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { CargoService } from '../../../services/CargoService/cargo-service';
import { CargoModel } from '../../../models/CargoModel/cargoModel';

@Component({
  selector: 'app-detalhes-cargo',
  imports: [RouterModule, CommonModule],
  templateUrl: './detalhes-cargo.html',
  styleUrl: './detalhes-cargo.css',
})
export class DetalhesCargo implements OnInit {
  cargo!: CargoModel;

  constructor(private cargoService: CargoService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.cargoService.BuscarCargoPorId(id).subscribe((response) => {
      this.cargo = response.dados;
    });
  }
}
