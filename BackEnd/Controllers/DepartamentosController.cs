using Mech.Domain;
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
    [HttpPost("")]
    [Produces("application/json"), Consumes("application/json")]
    [ProducesResponseType(typeof(DepartamentoOut), 200)]
    public async Task<IActionResult> Create([FromBody] DepartamentoIn data)
    {
        var departamento = new Departamento
        {
            Nome = data.Nome,
            Descricao = data.Descricao
        };

        ctx.Add(departamento);
        await ctx.SaveChangesAsync();

        return Ok(new DepartamentoOut { Id = departamento.Id, Nome = departamento.Nome, Descricao = departamento.Descricao });
    }

    /// <summary>
    /// Retorna todos os departamentos.
    /// </summary>
    [HttpGet("")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(List<DepartamentoOut>), 200)]
    public async Task<IActionResult> GetAll()
    {
        var departamentos = await ctx.Departamentos.ToListAsync();

        return Ok(departamentos.ConvertAll(d => new DepartamentoOut { Id = d.Id, Nome = d.Nome, Descricao = d.Descricao }));
    }
}
