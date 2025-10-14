using System.ComponentModel.DataAnnotations;

namespace backend.Dto.Departamento
{
    public class DepartamentoCriacaoDto
    {
        [Required(ErrorMessage = "O nome do departamento é obrigatório.")]
        public string Nome { get; set; }
        [StringLength(250, ErrorMessage = "A descrição deve ter no máximo 250 caracteres.")]
        public string Descricao { get; set; }
    }
}
