using Mech.Database;
using Mech.Code.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mech.Code.Controllers;

[ApiController, Route("[controller]")]
public class PacientesController(MechDbContext ctx) : ControllerBase
{
    /// <summary>
    /// Retorna todos os pacientes e seus respectivos endereços.
    /// </summary>
    [HttpGet("")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(PacienteOut), 200)]
    public async Task<IActionResult> GetAll()
    {
        FormattableString sql = $@"
            SELECT
                p.id,
                p.cpf,
                p.cns,
                p.nome,
                p.data_de_nascimento,
                g.nome AS genero,
                c.nome AS cidade,
                c.estado_id AS estado,
                e.cep,
                e.rua,
                e.bairro
            FROM
                mech.pacientes p
            INNER JOIN
                mech.generos g ON g.id = p.genero_id
            INNER JOIN
                mech.enderecos e ON e.id = p.endereco_id
            INNER JOIN
                mech.cidades c ON c.id = e.cidade_id
            ORDER BY
                p.id
        ";

        var pacientes = await ctx.Database.SqlQuery<PacienteOut>(sql).ToListAsync();

        return Ok(pacientes);
    }
}

