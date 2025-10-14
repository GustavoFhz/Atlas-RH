using backend.Enum;
using System.ComponentModel.DataAnnotations;

namespace backend.Dto.Cargo
{
    public class CargoCriacaoDto
    {
        [Required(ErrorMessage = "O nome do cargo é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O nível do cargo é obrigatório.")]
        [EnumDataType(typeof(NivelCargo), ErrorMessage = "Nível inválido.")]
        public NivelCargo Nivel { get; set; }

        [StringLength(250, ErrorMessage = "A descrição deve ter no máximo 250 caracteres.")]
        public string? Descricao { get; set; }
    }
}
