using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalSolution.DTO
{
    public class UpdateLembreteDTO
    {
        [Required]
        public string Mensagem { get; set; } = null!;

        [Required]
        public DateTime DataHora { get; set; }

        [Required]
        public long UsuarioId { get; set; }
    }
}