using System.ComponentModel.DataAnnotations;

namespace backend.Dto.Usuario
{
    public class UsuarioCriacaoDto
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O nome de usuário é obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome de usuário deve ter no máximo 50 caracteres.")]
        public string UsuarioLogin { get; set; }

        [Required(ErrorMessage = "Digite a Senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Digite a Confirmação de Senha"),
            Compare("Senha", ErrorMessage = "As senhas não são iguais")]
        public string ConfirmaSenha { get; set; }
    }
}
