using Mech.Database;
using Mech.Code.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mech.Code.Controllers;

[ApiController, Route("[controller]")]
public class EstadiasController(MechDbContext ctx) : ControllerBase
{
    /// <summary>
    /// Cria uma nova estadia.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(201)]
    [Produces("application/json"), Consumes("application/json")]
    public async Task<IActionResult> Create([FromBody] EstadiaIn data )
    {
        var paciente = await ctx.Pacientes.FirstOrDefaultAsync(x => x.Id == data.PacienteId);
        if (paciente == null) return BadRequest("Paciente não encontrado.");

        var medico = await ctx.Medicos.FirstOrDefaultAsync(x => x.Id == data.MedicoId);
        if (medico == null) return BadRequest("Médico não encontrado.");

        var quarto = await ctx.Quartos.FirstOrDefaultAsync(x => x.Id == data.QuartoId);
        if (quarto == null) return BadRequest("Quarto não encontrado.");
        if (quarto.EstaOcupado) return BadRequest("Quarto ocupado.");

        var estadia = new Estadia(
            data.PacienteId,
            data.MedicoId,
            data.QuartoId,
            data.MotivoDaAdmissao,
            data.DataDaAdmissao
        );
        ctx.Estadias.Add(estadia);

        quarto.EstaOcupado = true;

        await ctx.SaveChangesAsync();

        return Created("", estadia.ToOut());
    }

    /// <summary>
    /// Retorna todas as estadias dos pacientes.
    /// </summary>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(EstadiaOut), 200)]
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
                mech.tipos_de_quarto tdq ON tdq.id = q.tipo_id
            ORDER BY
                e.id
        ";

        var medicos = await ctx.Database.SqlQuery<EstadiaOut>(sql).ToListAsync();

        return Ok(medicos);
    }
}
