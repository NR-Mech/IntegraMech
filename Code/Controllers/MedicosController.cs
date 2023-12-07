using Mech.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mech.Code.Controllers;

[ApiController, Route("[controller]")]
public class MedicosController : ControllerBase
{
    private readonly MechDbContext _ctx;
    public MedicosController(MechDbContext ctx) => _ctx = ctx;

    [HttpGet("")]
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

        var medicos = await _ctx.Database.SqlQuery<MedicoOut>(sql).ToListAsync();

        return Ok(medicos);
    }
}

public class MedicoOut
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public string[] Especialidades { get; set; }
}
