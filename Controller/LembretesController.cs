using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GlobalSolution.Data;
using GlobalSolution.Models;
using GlobalSolution.DTO;

namespace GlobalSolution.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class LembretesController : ControllerBase
    {
        private readonly AppDbContext _ctx;

        public LembretesController(AppDbContext ctx) => _ctx = ctx;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LembreteDTO>>> GetAll()
        {
            var lista = await _ctx.Lembretes
                .AsNoTracking()
                .Select(l => new LembreteDTO {
                    Id        = l.Id,
                    Mensagem  = l.Mensagem,
                    DataHora  = l.DataHora,
                    UsuarioId = l.UsuarioId
                })
                .ToListAsync();

            return Ok(lista);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<LembreteDTO>> GetById(int id)
        {
            var lemb = await _ctx.Lembretes
                .AsNoTracking()
                .Where(l => l.Id == id)
                .Select(l => new LembreteDTO {
                    Id        = l.Id,
                    Mensagem  = l.Mensagem,
                    DataHora  = l.DataHora,
                    UsuarioId = l.UsuarioId
                })
                .FirstOrDefaultAsync();

            if (lemb == null) return NotFound();
            return Ok(lemb);
        }

        // POST v1/lembrentes
        [HttpPost]
        [HttpPost]
        public async Task<ActionResult<LembreteDTO>> Create([FromBody] CreateLembreteDTO dto)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var novo = new Lembrete
            {
                Mensagem  = dto.Mensagem,
                DataHora  = dto.DataHora,
                UsuarioId = dto.UsuarioId
            };

            _ctx.Lembretes.Add(novo);
            await _ctx.SaveChangesAsync();

            var result = new LembreteDTO
            {
                Id        = novo.Id,
                Mensagem  = novo.Mensagem,
                DataHora  = novo.DataHora,
                UsuarioId = novo.UsuarioId
            };

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }


        // PUT v1/lembrentes/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateLembreteDTO dto)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var existente = await _ctx.Lembretes.FindAsync(id);
            if (existente is null) return NotFound();

            existente.Mensagem  = dto.Mensagem;
            existente.DataHora  = dto.DataHora;
            existente.UsuarioId = dto.UsuarioId;

            await _ctx.SaveChangesAsync();
            return NoContent();
        }

        // DELETE v1/lembrentes/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var lemb = await _ctx.Lembretes.FindAsync(id);
            if (lemb == null) return NotFound();

            _ctx.Lembretes.Remove(lemb);
            await _ctx.SaveChangesAsync();
            return NoContent();
        }
    }
}
