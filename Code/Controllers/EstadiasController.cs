using Mech.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mech.Code.Controllers;

[ApiController, Route("[controller]")]
public class EstadiasController : ControllerBase
{
    private readonly MechDbContext _ctx;
    public EstadiasController(MechDbContext ctx) => _ctx = ctx;

    [HttpGet("")]
    public async Task<IActionResult> GetAll()
    {
        FormattableString sql = $@"
            SELECT
                e.id,
                p.nome AS paciente,
                m.nome AS medico,
                tdq.nome AS quarto,
                e.motivo_da_admissao,
                e.data_da_admissao,
                e.data_da_alta
            FROM
                mech.estadias e
            INNER JOIN
                mech.pacientes p ON p.id = e.paciente_id
            INNER JOIN
                mech.medicos m ON m.id = e.medico_id
            INNER JOIN
                mech.quartos q ON q.id = e.quarto_id
            INNER JOIN
                mech.tipos_de_quarto tdq ON tdq.id = q.tipo_de_quarto_id
            ORDER BY
                e.id
        ";

        var medicos = await _ctx.Database.SqlQuery<EstadiaOut>(sql).ToListAsync();

        return Ok(medicos);
    }
}

public class EstadiaOut
{
    public long Id { get; set; }
    public string Paciente { get; set; }
    public string Medico { get; set; }
    public string Quarto { get; set; }
    public string MotivoDaAdmissao { get; set; }
    public DateTime DataDaAdmissao { get; set; }
    public DateTime? DataDaAlta { get; set; }
}
