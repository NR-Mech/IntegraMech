using Mech.Database;
using Mech.Code.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mech.Code.Controllers;

[ApiController, Route("[controller]")]
public class QuartosController(MechDbContext ctx) : ControllerBase
{
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(List<CidadeOut>), 200)]
    public async Task<IActionResult> GetAll()
    {
        var quartos = await ctx.Quartos.Include(x => x.Tipo).OrderBy(e => e.Id).ToListAsync();

        return Ok(quartos.ConvertAll(e => e.ToOut()));
    }
}
