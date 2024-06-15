using Mech.Database;
using Mech.Code.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Mech.Code.Controllers;

[ApiController, Route("[controller]")]
public class EspecialidadesController(MechDbContext ctx) : ControllerBase
{
    /// <summary>
    /// Cria uma nova especialidade.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(201)]
    [Produces("application/json"), Consumes("application/json")]
    public async Task<IActionResult> Create([FromBody] EspecialidadeIn data )
    {
        var especialidade = new Especialidade(data.Nome);
        ctx.Especialidades.Add(especialidade);

        await ctx.SaveChangesAsync();

        return Created("", especialidade.ToOut());
    }

    /// <summary>
    /// Atualiza uma especialidade.
    /// </summary>
    [HttpPut("{id}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(EspecialidadeOut), 200)]
    public async Task<IActionResult> Update([FromRoute] long id, [FromBody] EspecialidadeIn data)
    {
        var especialidade = await ctx.Especialidades.FirstOrDefaultAsync(e => e.Id == id);

        if (especialidade == null)
            return NotFound();

        especialidade.Update(data.Nome);
        await ctx.SaveChangesAsync();

        return Ok(especialidade.ToOut());
    }

    /// <summary>
    /// Retorna todas as especialidades.
    /// </summary>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(List<EspecialidadeOut>), 200)]
    public async Task<IActionResult> GetAll()
    {
        var especialidades = await ctx.Especialidades.OrderBy(e => e.Nome).ToListAsync();

        return Ok(especialidades.ConvertAll(e => e.ToOut()));
    }

    /// <summary>
    /// Deleta uma especialidade.
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(NoContent),204)]
    public async Task<IActionResult> Delete([FromRoute] long id)
    {
        var especialidade = await ctx.Especialidades.FirstOrDefaultAsync(e => e.Id == id);

        if (especialidade == null)
            return NotFound();

        ctx.Remove(especialidade!);
        await ctx.SaveChangesAsync();

        return NoContent();
    }
}
