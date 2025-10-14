using backend.Enum;
using System.ComponentModel.DataAnnotations;

namespace backend.Dto.Funcionario
{
    public class FuncionarioEdicaoDto
    {
        [Required(ErrorMessage = "O ID é obrigatório.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O salário é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O salário deve ser maior que zero.")]
        public decimal Salario { get; set; }

        [Required(ErrorMessage = "O status é obrigatório.")]
        public StatusFuncionario Status { get; set; }

        [Required(ErrorMessage = "O departamento é obrigatório.")]
        public int DepartamentoId { get; set; }

        [Required(ErrorMessage = "O cargo é obrigatório.")]
        public int CargoId { get; set; }
    }
}
