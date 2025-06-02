using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GlobalSolution.Data;
using GlobalSolution.Models;

namespace GS.NET.Pages_Usuarios
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        public IndexModel(AppDbContext context) => _context = context;

        public List<Usuario> Usuarios { get; set; } = new();

        public async Task OnGetAsync()
        {
            Usuarios = await _context.Usuario
                .Include(u => u.Localizacao)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}