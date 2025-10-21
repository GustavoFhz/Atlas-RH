using backend.Dto.Cep;
using System.Text.Json;

namespace backend.Services.Cep
{
    public class CepService : ICepInterface
    {
        private readonly HttpClient _httpClient;
        public CepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CepResponse> EnderecoPorCep(string cep)
        {
            try
            {
                var endereco = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
                endereco.EnsureSuccessStatusCode();

                var json = await endereco.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<CepResponse>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });
            }

            catch
            {
                return null;
            }
        }
    }
}
