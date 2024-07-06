using EjemploEntity.Models;

namespace EjemploEntity.Interfaces
{
    public interface IVentas
    {
        Task<Respuesta> GetVentas(string? numFactura, double precio, double vendedor, double clienteId);

        Task<Respuesta> PostVenta(Venta venta);
        Task<Respuesta> PutVenta(Venta venta);
        Task<Respuesta> GetVentaReporte();
    }
}
