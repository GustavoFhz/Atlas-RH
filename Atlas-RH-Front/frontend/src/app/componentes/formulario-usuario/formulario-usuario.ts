import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { UsuarioCriacaoDto } from '../../models/UsuarioModel/usuarioCriacaoDto';
import { UsuarioEdicaoDto } from '../../models/UsuarioModel/usuarioEdicaoDto';

@Component({
  selector: 'app-formulario-usuario',
  imports: [FormsModule, ReactiveFormsModule, CommonModule, RouterModule],
  templateUrl: './formulario-usuario.html',
  styleUrl: './formulario-usuario.css',
})
export class FormularioUsuario implements OnInit {
  @Input() btnAcao!: string;
  @Input() descTitulo!: string;
  @Input() dadosUsuarios: UsuarioCriacaoDto | UsuarioEdicaoDto | null = null;
  @Output() onSubmit = new EventEmitter();

  usuarioForm!: FormGroup;

  ngOnInit(): void {
    const isCadastro = this.btnAcao === 'Cadastrar';

    this.usuarioForm = new FormGroup({
      id: new FormControl(
        this.dadosUsuarios && 'id' in this.dadosUsuarios ? this.dadosUsuarios.id : 0
      ),
      nome: new FormControl(this.dadosUsuarios ? this.dadosUsuarios.nome : '', [
        Validators.required,
      ]),
      usuarioLogin: new FormControl(this.dadosUsuarios ? this.dadosUsuarios.usuarioLogin : '', [
        Validators.required,
      ]),
      senha: new FormControl(
        this.dadosUsuarios && 'senha' in this.dadosUsuarios ? this.dadosUsuarios.senha : '',
        isCadastro ? Validators.required : []
      ),
      confirmaSenha: new FormControl(
        this.dadosUsuarios && 'confirmaSenha' in this.dadosUsuarios
          ? this.dadosUsuarios.confirmaSenha
          : '',
        isCadastro ? Validators.required : []
      ),
    });
  }

  submit(): void {
    if (this.usuarioForm.valid) {
      if (this.dadosUsuarios && (this.dadosUsuarios as UsuarioEdicaoDto).id) {
        this.onSubmit.emit(this.usuarioForm.value as UsuarioEdicaoDto);
      } else {
        this.onSubmit.emit(this.usuarioForm.value as UsuarioCriacaoDto);
      }
    } else {
      this.usuarioForm.markAllAsTouched(); //Marca todos os campos que nao digitou com o required
    }
  }
}
