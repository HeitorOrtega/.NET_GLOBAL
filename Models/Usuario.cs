using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GlobalSolution.Models
{
    public class Usuario
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Nome { get; set; }

        [Required]
        [MinLength(6)]
        public string Senha { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string Cpf { get; set; } = string.Empty;

        public long? LocalizacaoId { get; set; }

        public Localizacao? Localizacao { get; set; }

        public List<Lembrete> Lembretes { get; set; } = new();

        public Usuario() { }

        public Usuario(string nome, string senha, string email, string cpf)
        {
            Nome = nome;
            Senha = senha;
            Email = email;
            Cpf = cpf;
        }
    }
}