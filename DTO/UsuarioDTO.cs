using System.ComponentModel.DataAnnotations;

namespace GlobalSolution.ViewModels
{
    public class UsuarioDTO
    {
        public long    Id             { get; set; }
        public string? Nome           { get; set; }  
        public string? Email          { get; set; }
        public string? Cpf            { get; set; }
        public long?   LocalizacaoId  { get; set; }
    }

    public class CreateUsuarioDto
    {
        [Required, MaxLength(100)]
        public string Nome { get; set; } = null!;

        [Required, MinLength(6)]
        public string Senha { get; set; } = null!;

        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        [Required, StringLength(11, MinimumLength = 11)]
        public string Cpf { get; set; } = null!;

        public long? LocalizacaoId { get; set; }
    }

    public class UpdateUsuarioDto
    {
        [Required, MaxLength(100)]
        public string Nome { get; set; } = null!;

        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        [Required, StringLength(11, MinimumLength = 11)]
        public string Cpf { get; set; } = null!;

        public long? LocalizacaoId { get; set; }
    }
}