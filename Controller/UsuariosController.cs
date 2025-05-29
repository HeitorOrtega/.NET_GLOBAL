// Controllers/UsuariosController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GlobalSolution.Data;
using GlobalSolution.Models;
using GlobalSolution.ViewModels;
using GS.NET.DTO;

namespace GlobalSolution.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _ctx;

        public UsuariosController(AppDbContext ctx)
            => _ctx = ctx;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetAll()
        {
            var usuarios = await _ctx.Usuario
                .AsNoTracking()
                .Select(u => new UsuarioDTO {
                    Id = u.Id,
                    Nome = u.Nome!,
                    Email = u.Email,
                    Cpf = u.Cpf,
                    LocalizacaoId = u.LocalizacaoId
                })
                .ToListAsync();

            return Ok(usuarios);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<UsuarioDTO>> GetById(long id)
        {
            var u = await _ctx.Usuario
                .AsNoTracking()
                .Where(u => u.Id == id)
                .Select(u => new UsuarioDTO() {
                    Id = u.Id,
                    Nome = u.Nome!,
                    Email = u.Email,
                    Cpf = u.Cpf,
                    LocalizacaoId = u.LocalizacaoId
                })
                .FirstOrDefaultAsync();

            if (u == null) return NotFound();
            return Ok(u);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioDTO>> Create([FromBody] CreateUsuarioDTO dto)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var u = new Usuario {
                Nome  = dto.Nome,
                Senha = dto.Senha,
                Email = dto.Email,
                Cpf   = dto.Cpf
            };

            _ctx.Usuario.Add(u);
            await _ctx.SaveChangesAsync();

            var result = new UsuarioDTO {
                Id            = u.Id,
                Nome          = u.Nome!,
                Email         = u.Email,
                Cpf           = u.Cpf,
                LocalizacaoId = u.LocalizacaoId  
            };
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateUsuarioDto dto)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var existente = await _ctx.Usuario.FindAsync(id);
            if (existente is null) return NotFound();

            existente.Nome = dto.Nome;
            existente.Email = dto.Email;
            existente.Cpf = dto.Cpf;
            existente.LocalizacaoId = dto.LocalizacaoId;

            await _ctx.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var u = await _ctx.Usuario.FindAsync(id);
            if (u == null) return NotFound();

            _ctx.Usuario.Remove(u);
            await _ctx.SaveChangesAsync();
            return NoContent();
        }
    }
}
