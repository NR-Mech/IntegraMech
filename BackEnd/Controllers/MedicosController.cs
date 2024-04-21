using Mech.Domain;
using Mech.Database;
using Mech.Code.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mech.Code.Controllers;

[ApiController, Route("[controller]")]
public class MedicosController(MechDbContext ctx) : ControllerBase
{
    /// <summary>
    /// Cria um novo médico.
    /// </summary>
    [HttpPost("")]
    [Produces("application/json"), Consumes("application/json")]
    [ProducesResponseType(201)]
    public async Task<IActionResult> Create([FromBody] MedicoIn data)
    {
        var medico = new Medico(data.Nome, data.CRM);
        ctx.Medicos.Add(medico);

        await ctx.SaveChangesAsync();

        return Created();
    }

    /// <summary>
    /// Retorna todos os médicos e suas respectivas especialidades.
    /// </summary>
    [HttpGet("")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(MedicoOut), 200)]
    public async Task<IActionResult> GetAll()
    {
        FormattableString sql = $@"
            SELECT
                m.id,
                m.nome,
                ARRAY_AGG(e.nome) AS especialidades
            FROM
                mech.medicos m
            LEFT JOIN
                mech.medicos__especialidades me ON me.medico_id = m.id
            LEFT JOIN
                mech.especialidades e ON e.id = me.especialidade_id
            GROUP BY
                m.id
            ORDER BY
                m.id
        ";

        var medicos = await ctx.Database.SqlQuery<MedicoOut>(sql).ToListAsync();

        return Ok(medicos);
    }
}
