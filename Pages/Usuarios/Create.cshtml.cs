using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GlobalSolution.Data;
using GlobalSolution.Models;

namespace GS.NET.Pages.Usuarios
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;
        public CreateModel(AppDbContext context) => _context = context;

        [BindProperty, Required, StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [BindProperty, Required, MinLength(6)]
        public string Senha { get; set; } = string.Empty;

        [BindProperty, Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [BindProperty, Required, StringLength(11, MinimumLength = 11)]
        public string Cpf { get; set; } = string.Empty;

        // Campos de endereço (nunca nulos)
        [BindProperty, Required, RegularExpression(@"^\d{8}$", ErrorMessage = "CEP deve ter 8 dígitos numéricos")]
        public string Cep { get; set; } = string.Empty;

        [BindProperty, Required, StringLength(150)]
        public string Logradouro { get; set; } = string.Empty;

        [BindProperty, Required, StringLength(10)]
        public string Numero { get; set; } = string.Empty;

        [BindProperty, StringLength(50)]
        public string? Complemento { get; set; }

        [BindProperty, Required, StringLength(100)]
        public string Bairro { get; set; } = string.Empty;

        [BindProperty, Required, StringLength(100)]
        public string Cidade { get; set; } = string.Empty;

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            // 1) Salva Localizacao
            var local = new Localizacao
            {
                Cep         = Cep,
                Logradouro  = Logradouro,
                Numero      = Numero,
                Complemento = Complemento,
                Bairro      = Bairro,
                Cidade      = Cidade
            };
            _context.Localizacao.Add(local);
            await _context.SaveChangesAsync();

            // 2) Salva Usuario apontando para a localizacao recém criada
            var user = new Usuario
            {
                Nome          = Nome,
                Senha         = Senha,
                Email         = Email,
                Cpf           = Cpf,
                LocalizacaoId = local.Id
            };
            _context.Usuario.Add(user);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
