using System.ComponentModel.DataAnnotations;

namespace GS.NET.ViewModels
{
    public class UsuarioInputModel
    {
        [Required, StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required, MinLength(6)]
        public string Senha { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, StringLength(11, MinimumLength = 11)]
        public string Cpf { get; set; } = string.Empty;

        [Required, StringLength(8, MinimumLength = 8, ErrorMessage = "O CEP deve ter exatamente 8 dígitos")]
        public string Cep { get; set; } = string.Empty;

        [Required, StringLength(150)]
        public string Logradouro { get; set; } = string.Empty;

        [Required, StringLength(10)]
        public string Numero { get; set; } = string.Empty;

        [StringLength(50)]
        public string? Complemento { get; set; }

        [Required, StringLength(100)]
        public string Bairro { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string Cidade { get; set; } = string.Empty;
    }
}