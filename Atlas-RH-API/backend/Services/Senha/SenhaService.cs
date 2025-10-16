using backend.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace backend.Services.Senha
{
    public class SenhaService : ISenhaInterface
    {
        private readonly IConfiguration _config;
        public SenhaService(IConfiguration config)
        {
            _config = config;
        }
        public void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                senhaSalt = hmac.Key; //chave aleatoria
                senhaHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
            }
        }

        public string CriarToken(UsuarioModel usuario)
        {
            List<Claim> claims = new()
        {
            new Claim("UsuarioLogin", usuario.UsuarioLogin),
            new Claim("UserId", usuario.Id.ToString())
            };

            // Pega a chave do .env
            var tokenSecret = Environment.GetEnvironmentVariable("JWT_SECRET") ?? throw new Exception("JWT_SECRET não encontrado.");
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(tokenSecret));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var expirationDays = int.Parse(Environment.GetEnvironmentVariable("JWT_EXPIRATION_DAYS") ?? "1");

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(expirationDays),
                signingCredentials: cred
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool VerificaSenhaHash(string senha, byte[] SenhaHash, byte[] SenhaSalt)
        {
            using (var hmac = new HMACSHA512(SenhaSalt))
            {
                var computerHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
                return computerHash.SequenceEqual(SenhaHash);
            }
        }
    }
}
