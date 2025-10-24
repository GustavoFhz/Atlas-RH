export interface UsuarioModel {
  id: number;
  nome: string;
  usuarioLogin: string;
  token: string;
  senhaHash: Uint8Array;
  senhaSalt: Uint8Array;
  novaSenha:string;
}
