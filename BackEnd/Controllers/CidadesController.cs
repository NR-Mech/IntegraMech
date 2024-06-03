using Mech.Database;
using Mech.Code.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mech.Code.Controllers;

[ApiController, Route("[controller]")]
public class CidadesController(MechDbContext ctx) : ControllerBase
{
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(List<CidadeOut>), 200)]
    public async Task<IActionResult> GetAll()
    {
        var cidades = await ctx.Cidades.Include(x => x.Estado).OrderBy(e => e.Nome).ToListAsync();

        return Ok(cidades.ConvertAll(e => e.ToOut()));
    }
}
