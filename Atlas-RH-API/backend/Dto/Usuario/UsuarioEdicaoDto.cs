using System.ComponentModel.DataAnnotations;

namespace backend.Dto.Usuario
{
    public class UsuarioEdicaoDto
    {
        [Required(ErrorMessage = "O ID do usuário é obrigatório.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O nome de usuário é obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome de usuário deve ter no máximo 50 caracteres.")]
        public string UsuarioLogin { get; set; }

        [StringLength(100, MinimumLength = 6, ErrorMessage = "A nova senha deve ter pelo menos 6 caracteres.")]
        public string? NovaSenha { get; set; }
    }
}
