// Pages/Usuarios/Create.cshtml.cs
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GlobalSolution.Data;
using GlobalSolution.Models;
using GS.NET.ViewModels;  

namespace GS.NET.Pages_Usuarios
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;
        public CreateModel(AppDbContext context) => _context = context;

        [BindProperty]
        public UsuarioInputModel Input { get; set; } = new();

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var local = new Localizacao
            {
                Cep         = Input.Cep,
                Logradouro  = Input.Logradouro,
                Numero      = Input.Numero,
                Complemento = Input.Complemento,
                Bairro      = Input.Bairro,
                Cidade      = Input.Cidade
            };
            _context.Localizacao.Add(local);
            await _context.SaveChangesAsync();

            var user = new Usuario
            {
                Nome          = Input.Nome,
                Senha         = Input.Senha,
                Email         = Input.Email,
                Cpf           = Input.Cpf,
                LocalizacaoId = local.Id
            };
            _context.Usuario.Add(user);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}