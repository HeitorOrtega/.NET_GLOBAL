using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution.Models
{
    public class Localizacao
    {
        public long Id { get; set; }

        [Column("LOGRADOURO"), Required, MaxLength(150)]
        public string Logradouro { get; set; } = string.Empty;

        [Column("NUMERO"), Required, MaxLength(10)]
        public string Numero { get; set; } = string.Empty;

        [Column("COMPLEMENTO"), MaxLength(50)]
        public string? Complemento { get; set; }

        [Column("BAIRRO"), MaxLength(100)]
        public string? Bairro { get; set; }

        [Column("CIDADE"), MaxLength(100)]
        public string? Cidade { get; set; }

        [NotMapped]
        public string Estado => "SP";

        [Column("CEP"), RegularExpression(@"^\d{8}$")]
        public string? Cep { get; set; }       

        public List<Usuario> Usuarios { get; set; } = new();
    }



}