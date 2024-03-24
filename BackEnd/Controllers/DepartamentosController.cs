using Mech.Code.Dtos;
using Mech.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mech.Code.Controllers;

[ApiController, Route("[controller]")]
public class DepartamentosController(MechDbContext ctx) : ControllerBase
{
    /// <summary>
    /// Retorna todos os departamentos.
    /// </summary>
    [HttpGet("")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(DepartamentoOut), 200)]
    public async Task<IActionResult> GetAll()
    {
        var departamentos = await ctx.Departamentos.ToListAsync();

        return Ok(departamentos.ConvertAll(d => new DepartamentoOut { Id = d.Id, Nome = d.Nome, Descricao = d.Descricao }));
    }
}
