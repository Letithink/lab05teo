using Lab05teo.Models;
using Lab05teo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab05teo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProyectosController : ControllerBase
{
    private readonly IProyectoService _service;

    public ProyectosController(IProyectoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Proyecto>>> GetAll()
    {
        var proyectos = await _service.GetAllAsync();
        return Ok(proyectos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Proyecto>> GetById(int id)
    {
        var proyecto = await _service.GetByIdAsync(id);

        if (proyecto == null)
            return NotFound();

        return Ok(proyecto);
    }

    [HttpPost]
    public async Task<ActionResult<Proyecto>> Create(Proyecto proyecto)
    {
        var nuevoProyecto = await _service.CreateAsync(proyecto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = nuevoProyecto.IdProyecto },
            nuevoProyecto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Proyecto proyecto)
    {
        var actualizado = await _service.UpdateAsync(id, proyecto);

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