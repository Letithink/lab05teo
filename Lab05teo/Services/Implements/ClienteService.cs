using Lab05teo.Models;
using Lab05teo.Services;
using Lab05teo.UnitOfWork;

namespace Lab05teo.Services.Implements;

public class ClienteService : IClienteService
{
    private readonly IUnitOfWork _unitOfWork;

    public ClienteService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Cliente>> GetAllAsync()
    {
        return await _unitOfWork.Clientes.GetAllAsync();
    }

    public async Task<Cliente?> GetByIdAsync(int id)
    {
        return await _unitOfWork.Clientes.GetByIdAsync(id);
    }

    public async Task<Cliente> CreateAsync(Cliente cliente)
    {
        await _unitOfWork.Clientes.AddAsync(cliente);
        await _unitOfWork.SaveChangesAsync();

        return cliente;
    }

    public async Task<bool> UpdateAsync(int id, Cliente cliente)
    {
        var clienteExistente = await _unitOfWork.Clientes.GetByIdAsync(id);

        if (clienteExistente == null)
            return false;

        clienteExistente.NombreEmpresa = cliente.NombreEmpresa;
        clienteExistente.NombreContacto = cliente.NombreContacto;
        clienteExistente.Correo = cliente.Correo;
        clienteExistente.Telefono = cliente.Telefono;

        _unitOfWork.Clientes.Update(clienteExistente);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var cliente = await _unitOfWork.Clientes.GetByIdAsync(id);

        if (cliente == null)
            return false;

        _unitOfWork.Clientes.Delete(cliente);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}