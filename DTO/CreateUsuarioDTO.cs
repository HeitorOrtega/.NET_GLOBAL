using System.ComponentModel.DataAnnotations;

namespace GS.NET.DTO;

public class CreateUsuarioDTO
{
    [Required, MaxLength(100)]
    public string Nome { get; set; } = null!;

    [Required, MinLength(6)]
    public string Senha { get; set; } = null!;

    [Required, EmailAddress]
    public string Email { get; set; } = null!;

    [Required, StringLength(11, MinimumLength = 11)]
    public string Cpf { get; set; } = null!;

    [Required]
    public long LocalizacaoId { get; set; }  
}
