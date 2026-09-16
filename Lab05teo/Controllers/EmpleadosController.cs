using Lab05teo.Models;
using Lab05teo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab05teo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmpleadosController : ControllerBase
{
    private readonly IEmpleadoService _service;

    public EmpleadosController(IEmpleadoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Empleado>>> GetAll()
    {
        var empleados = await _service.GetAllAsync();
        return Ok(empleados);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Empleado>> GetById(int id)
    {
        var empleado = await _service.GetByIdAsync(id);

        if (empleado == null)
            return NotFound();

        return Ok(empleado);
    }

    [HttpPost]
    public async Task<ActionResult<Empleado>> Create(Empleado empleado)
    {
        var nuevoEmpleado = await _service.CreateAsync(empleado);

        return CreatedAtAction(
            nameof(GetById),
            new { id = nuevoEmpleado.IdEmpleado },
            nuevoEmpleado);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Empleado empleado)
    {
        var actualizado = await _service.UpdateAsync(id, empleado);

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