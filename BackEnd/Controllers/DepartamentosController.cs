using Mech.Database;
using Mech.Code.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mech.Code.Controllers;

[ApiController, Route("[controller]")]
public class DepartamentosController(MechDbContext ctx) : ControllerBase
{
    /// <summary>
    /// Cria um novo departamento.
    /// </summary>
    [HttpPost]
    [Produces("application/json"), Consumes("application/json")]
    [ProducesResponseType(typeof(DepartamentoOut), 200)]
    public async Task<IActionResult> Create([FromBody] DepartamentoIn data)
    {
        var departamento = new Departamento(data.Nome, data.Descricao);

        ctx.Add(departamento);
        await ctx.SaveChangesAsync();

        return Created("", departamento.ToOut());
    }

    /// <summary>
    /// Retorna todos os departamentos.
    /// </summary>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(List<DepartamentoOut>), 200)]
    public async Task<IActionResult> GetAll()
    {
        var departamentos = await ctx.Departamentos.OrderBy(x => x.Nome).ToListAsync();

        return Ok(departamentos.ConvertAll(d => d.ToOut()));
    }
}
