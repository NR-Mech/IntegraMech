using Mech.Database;
using Mech.Code.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mech.Code.Controllers;

[ApiController, Route("[controller]")]
public class GenerosController(MechDbContext ctx) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(201)]
    [Produces("application/json"), Consumes("application/json")]
    public async Task<IActionResult> Create([FromBody] GeneroIn data )
    {
        var genero = new Genero(data.Nome);
        ctx.Generos.Add(genero);

        await ctx.SaveChangesAsync();

        return Created("", genero.ToOut());
    }

    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(List<GeneroOut>), 200)]
    public async Task<IActionResult> GetAll()
    {
        var generos = await ctx.Generos.OrderBy(e => e.Nome).ToListAsync();

        return Ok(generos.ConvertAll(e => e.ToOut()));
    }
}
