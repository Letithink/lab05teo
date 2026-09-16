using Lab05teo.Models;
using Lab05teo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab05teo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GastosController : ControllerBase
{
    private readonly IGastoService _service;

    public GastosController(IGastoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Gasto>>> GetAll()
    {
        var gastos = await _service.GetAllAsync();
        return Ok(gastos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Gasto>> GetById(int id)
    {
        var gasto = await _service.GetByIdAsync(id);

        if (gasto == null)
            return NotFound();

        return Ok(gasto);
    }

    [HttpPost]
    public async Task<ActionResult<Gasto>> Create(Gasto gasto)
    {
        var nuevoGasto = await _service.CreateAsync(gasto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = nuevoGasto.IdGasto },
            nuevoGasto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Gasto gasto)
    {
        var actualizado = await _service.UpdateAsync(id, gasto);

        if (!actualizado)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminado = await _service.DeleteAsync(id);

        if (!eliminado)
            return NotFound();

        return NoContent();
    }
}