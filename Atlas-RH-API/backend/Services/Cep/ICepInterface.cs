using backend.Dto.Cep;

namespace backend.Services.Cep
{
    public interface ICepInterface
    {
        Task<CepResponse> EnderecoPorCep(string cep);
    }
}
