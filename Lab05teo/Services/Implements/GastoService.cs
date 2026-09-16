using Lab05teo.Models;
using Lab05teo.Services;
using Lab05teo.UnitOfWork;

namespace Lab05teo.Services.Implements;

public class GastoService : IGastoService
{
    private readonly IUnitOfWork _unitOfWork;

    public GastoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Gasto>> GetAllAsync()
    {
        return await _unitOfWork.Gastos.GetAllAsync();
    }

    public async Task<Gasto?> GetByIdAsync(int id)
    {
        return await _unitOfWork.Gastos.GetByIdAsync(id);
    }

    public async Task<Gasto> CreateAsync(Gasto gasto)
    {
        await _unitOfWork.Gastos.AddAsync(gasto);
        await _unitOfWork.SaveChangesAsync();

        return gasto;
    }

    public async Task<bool> UpdateAsync(int id, Gasto gasto)
    {
        var gastoExistente = await _unitOfWork.Gastos.GetByIdAsync(id);

        if (gastoExistente == null)
            return false;

        gastoExistente.IdProyecto = gasto.IdProyecto;
        gastoExistente.Concepto = gasto.Concepto;
        gastoExistente.Monto = gasto.Monto;
        gastoExistente.FechaGasto = gasto.FechaGasto;
        gastoExistente.Descripcion = gasto.Descripcion;

        _unitOfWork.Gastos.Update(gastoExistente);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var gasto = await _unitOfWork.Gastos.GetByIdAsync(id);

        if (gasto == null)
            return false;

        _unitOfWork.Gastos.Delete(gasto);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}