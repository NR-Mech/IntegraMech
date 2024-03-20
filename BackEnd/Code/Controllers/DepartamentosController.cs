using Mech.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mech.Code.Controllers;

[ApiController, Route("[controller]")]
public class DepartamentosController : ControllerBase
{
    private readonly MechDbContext _ctx;
    public DepartamentosController(MechDbContext ctx) => _ctx = ctx;

    [HttpGet("")]
    public async Task<IActionResult> GetAll()
    {
        var departamentos = await _ctx.Departamentos.ToListAsync();

        return Ok(departamentos);
    }
}
