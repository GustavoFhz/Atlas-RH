using backend.Enum;

namespace backend.Models
{
    public class FuncionarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public decimal Salario { get; set; }
        public DateTime DataAdmissao { get; set; } = DateTime.Now;
        public StatusFuncionario Status { get; set; }
        public int DepartamentoId { get; set; }
        public DepartamentoModel? Departamento { get; set; }
        public int CargoId { get; set; }
        public CargoModel? Cargo { get; set; }
       
    }
}
