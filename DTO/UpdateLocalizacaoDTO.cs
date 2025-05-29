using System.ComponentModel.DataAnnotations;

namespace GlobalSolution.DTO
{
    public class UpdateLocalizacaoDTO
    {
        [Required, MaxLength(150)]
        public string Logradouro { get; set; } = null!;

        [Required, MaxLength(10)]
        public string Numero { get; set; } = null!;

        [MaxLength(50)]
        public string? Complemento { get; set; }

        [Required, MaxLength(100)]
        public string Bairro { get; set; } = null!;

        [Required, MaxLength(100)]
        public string Cidade { get; set; } = null!;

        [Required, RegularExpression(@"^\d{8}$")]
        public string Cep { get; set; } = null!;
    }
}