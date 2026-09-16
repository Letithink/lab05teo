using Lab05teo.Models;
using Lab05teo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab05teo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly IClienteService _service;

    public ClientesController(IClienteService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cliente>>> GetAll()
    {
        var clientes = await _service.GetAllAsync();
        return Ok(clientes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Cliente>> GetById(int id)
    {
        var cliente = await _service.GetByIdAsync(id);

        if (cliente == null)
            return NotFound();

        return Ok(cliente);
    }

    [HttpPost]
    public async Task<ActionResult<Cliente>> Create(Cliente cliente)
    {
        var nuevoCliente = await _service.CreateAsync(cliente);

        return CreatedAtAction(
            nameof(GetById),
            new { id = nuevoCliente.IdCliente },
            nuevoCliente);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Cliente cliente)
    {
        var actualizado = await _service.UpdateAsync(id, cliente);

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