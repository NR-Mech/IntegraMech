using Mech.Database;
using Mech.Code.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mech.Code.Controllers;

[ApiController, Route("[controller]")]
public class QuartosController(MechDbContext ctx) : ControllerBase
{
    /// <summary>
    /// Retorna todos os quartos.
    /// </summary>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(List<QuartoOut>), 200)]
    public async Task<IActionResult> GetAll()
    {
        var quartos = await ctx.Quartos.Include(x => x.Tipo).OrderBy(e => e.Id).ToListAsync();

        return Ok(quartos.ConvertAll(e => e.ToOut()));
    }
}
