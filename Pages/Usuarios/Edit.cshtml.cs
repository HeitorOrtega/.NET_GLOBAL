using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GlobalSolution.Data;
using GlobalSolution.Models;
using GS.NET.ViewModels; 
namespace GS.NET.Pages_Usuarios
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;
        public EditModel(AppDbContext context) => _context = context;

        [BindProperty]
        public UsuarioInputModel Input { get; set; } = new();

        public long Id { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
                return NotFound();

            var usuario = await _context.Usuario
                                        .Include(u => u.Localizacao)
                                        .FirstOrDefaultAsync(u => u.Id == id.Value);
            if (usuario == null)
                return NotFound();

            Id = usuario.Id;
            Input = new UsuarioInputModel
            {
                Nome       = usuario.Nome!,
                Senha      = usuario.Senha!,   
                Email      = usuario.Email!,
                Cpf        = usuario.Cpf!,
                Cep        = usuario.Localizacao.Cep,
                Logradouro = usuario.Localizacao.Logradouro,
                Numero     = usuario.Localizacao.Numero,
                Complemento= usuario.Localizacao.Complemento,
                Bairro     = usuario.Localizacao.Bairro,
                Cidade     = usuario.Localizacao.Cidade
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
                return NotFound();

            if (!ModelState.IsValid)
                return Page();

            var existente = await _context.Usuario
                                         .Include(u => u.Localizacao)
                                         .FirstOrDefaultAsync(u => u.Id == id.Value);
            if (existente == null)
                return NotFound();

            existente.Localizacao.Cep        = Input.Cep;
            existente.Localizacao.Logradouro = Input.Logradouro;
            existente.Localizacao.Numero     = Input.Numero;
            existente.Localizacao.Complemento= Input.Complemento;
            existente.Localizacao.Bairro     = Input.Bairro;
            existente.Localizacao.Cidade     = Input.Cidade;

            existente.Nome   = Input.Nome;
            existente.Email  = Input.Email;
            existente.Cpf    = Input.Cpf;
            existente.Senha  = Input.Senha; 

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Usuario.Any(e => e.Id == id.Value))
                    return NotFound();
                else
                    throw;
            }

            return RedirectToPage("./Index");
        }
    }
}
