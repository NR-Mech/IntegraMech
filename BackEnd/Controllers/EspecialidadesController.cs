using Mech.Code.Dtos;
using Mech.Code.Dtos.Input;
using Mech.Database;
using Mech.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mech.Code.Controllers;

[ApiController, Route("[controller]")]
public class EspecialidadesController(MechDbContext ctx) : ControllerBase
{

    [HttpGet("")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(EspecialidadeOut), 200)]
    public async Task<IActionResult> GetAll()
    {
        var especialidades = await ctx.Especialidades.ToListAsync();


        return Ok(especialidades.ConvertAll(e => new EspecialidadeOut { Id = e.Id, Nome = e.Nome }));

    }
    [HttpPost("criar")]
    [Produces("application/json")]
    [ProducesResponseType(201)]
    public async Task<IActionResult> Create([FromBody] EspecialidadeIn data )
    {
        var entity = new Especialidade { Nome = data.Nome };
        ctx.Especialidades.Add(entity);

        await ctx.SaveChangesAsync();

        return Created();
    }

    [HttpPut("atualizar/{id}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(EspecialidadeOut), 200)]
    public async Task<IActionResult> Update(long id,[FromBody] EspecialidadeIn data)
    {

        var entity = ctx.Especialidades.First(e => e.Id == id);

        if (entity == null)
            return BadRequest();


        entity.Nome = data.Nome;

        ctx.Especialidades.Update(entity);

        await ctx.SaveChangesAsync();

        return Ok(new EspecialidadeOut { Id = entity.Id, Nome = entity.Nome });

    }

    [HttpDelete("deletar/{id}")]
    [ProducesResponseType(typeof(NoContent),204)]
    public async Task<IActionResult> Delete(long id){

        var entity = ctx.Especialidades.First(e => e.Id == id);

        ctx.Remove(entity);

        await ctx.SaveChangesAsync();

        return NoContent();
    }
}