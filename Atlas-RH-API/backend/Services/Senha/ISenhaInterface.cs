using backend.Models;

namespace backend.Services.Senha
{
    public interface ISenhaInterface
    {
        // Gera o hash e o salt da senha informada.
        // - senha: a senha em texto puro fornecida pelo usuário
        // - senhaHash: saída contendo a senha criptografada (hash)
        // - senhaSalt: saída contendo a chave usada para gerar o hash, garantindo que hashes iguais de senhas iguais sejam únicos
        void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt);
        bool VerificaSenhaHash(string senha, byte[] SenhaHash, byte[] SenhaSalt);
        string CriarToken(UsuarioModel usuario);


    }
}
