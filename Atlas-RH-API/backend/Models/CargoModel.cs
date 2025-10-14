using backend.Enum;

namespace backend.Models
{
    public class CargoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public NivelCargo Nivel { get; set; }
        public string Descricao { get; set; }
    }
}
