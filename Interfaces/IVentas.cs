using EjemploEntity.Models;

namespace EjemploEntity.Interfaces
{
    public interface IVentas
    {
        Task<Respuesta> GetCliente(string? numFactura, double precio, double vendedor, double clienteId);
    }
}
