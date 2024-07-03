using EjemploEntity.Models;

namespace EjemploEntity.Interfaces
{
    public interface ICliente
    {
        Task<Respuesta> GetCliente(double clienteId, string? nombreCliente, double identificacion);
        Task<Respuesta> PostCliente(Cliente cliente);
        Task<Respuesta> PutCliente(Cliente cliente);
    }
}
