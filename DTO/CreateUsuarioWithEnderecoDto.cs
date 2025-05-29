using System.ComponentModel.DataAnnotations;
using GlobalSolution.DTO;
using GS.NET.DTO;


namespace GlobalSolution.ViewModels
{
    public class CreateUsuarioWithEnderecoDTO : CreateUsuarioDTO
    {
        [Required]
        public CreateLocalizacaoDTO Endereco { get; set; } = null!;
    }

}