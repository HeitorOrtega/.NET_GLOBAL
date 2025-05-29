using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GlobalSolution.Data;
using GlobalSolution.Models;

namespace GS.NET.Pages_Usuarios
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        public IList<Usuario> Usuarios { get; set; } = default!;

        public IndexModel(AppDbContext context) => _context = context;

        public async Task OnGetAsync()
        {
            Usuarios = await _context.Usuario
                .Include(u => u.Localizacao)  
                .ToListAsync();
        }
    }
}