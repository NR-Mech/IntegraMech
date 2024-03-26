using Mech.Code.Dtos;
using Mech.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mech.Code.Controllers;

[ApiController, Route("[controller]")]
public class MedicosController(MechDbContext ctx) : ControllerBase
{
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

