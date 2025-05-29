using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalSolution.Models
{
    public class Lembrete
    {
        public int Id { get; set; }

        [Required]
        public string Mensagem { get; set; } = string.Empty;

        [Required]
        public DateTime DataHora { get; set; }

        public long UsuarioId { get; set; }

        public  Usuario? Usuario { get; set; }

        public Lembrete(string mensagem, DateTime dataHora)
        {
            Mensagem = mensagem;
            DataHora = dataHora;
        }

        public Lembrete() { }
    }
}