using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GlobalSolution.Data;
using GlobalSolution.Models;
using GlobalSolution.DTO;
using GlobalSolution.ViewModels;      

namespace GlobalSolution.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class LocalizacoesController : ControllerBase
    {
        private readonly AppDbContext _ctx;
        public LocalizacoesController(AppDbContext ctx) => _ctx = ctx;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocalizacaoDTO>>> GetAll()
        {
            var lista = await _ctx.Localizacao
                .AsNoTracking()
                .Select(l => new LocalizacaoDTO {
                    Id         = l.Id,
                    Logradouro = l.Logradouro,
                    Numero     = l.Numero,
                    Complemento= l.Complemento,
                    Bairro     = l.Bairro,
                    Cidade     = l.Cidade,
                    Cep        = l.Cep,
                    Estado     = "SP"
                })
                .ToListAsync();

            return Ok(lista);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<LocalizacaoDTO>> GetById(long id)
        {
            var loc = await _ctx.Localizacao
                .AsNoTracking()
                .Where(l => l.Id == id)
                .Select(l => new LocalizacaoDTO {
                    Id         = l.Id,
                    Logradouro = l.Logradouro,
                    Numero     = l.Numero,
                    Complemento= l.Complemento,
                    Bairro     = l.Bairro,
                    Cidade     = l.Cidade,
                    Cep        = l.Cep,
                    Estado     = "SP"
                })
                .FirstOrDefaultAsync();

            if (loc == null) return NotFound();
            return Ok(loc);
        }

        [HttpPost]
        public async Task<ActionResult<LocalizacaoDTO>> Create([FromBody] CreateLocalizacaoDTO dto)
        {
            var loc = new Localizacao {
                Logradouro  = dto.Logradouro,
                Numero      = dto.Numero,
                Complemento = dto.Complemento,
                Bairro      = dto.Bairro,
                Cidade      = dto.Cidade,
                Cep         = dto.Cep
            };
            _ctx.Localizacao.Add(loc);
            await _ctx.SaveChangesAsync();

            var result = new LocalizacaoDTO {
                Id         = loc.Id,
                Logradouro = loc.Logradouro,
                Numero     = loc.Numero,
                Complemento= loc.Complemento,
                Bairro     = loc.Bairro,
                Cidade     = loc.Cidade,
                Cep        = loc.Cep,
                Estado     = "SP"
            };
            return CreatedAtAction(nameof(GetById), new { id = loc.Id }, result);
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateLocalizacaoDTO dto)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var existente = await _ctx.Localizacao.FindAsync(id);
            if (existente is null) return NotFound();

            existente.Logradouro = dto.Logradouro;
            existente.Numero     = dto.Numero;
            existente.Complemento= dto.Complemento;
            existente.Bairro     = dto.Bairro;
            existente.Cidade     = dto.Cidade;
            existente.Cep        = dto.Cep;

            await _ctx.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var loc = await _ctx.Localizacao.FindAsync(id);
            if (loc == null) return NotFound();

            _ctx.Localizacao.Remove(loc);
            await _ctx.SaveChangesAsync();
            return NoContent();
        }
    }
}
