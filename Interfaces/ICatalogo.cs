using EjemploEntity.Models;

namespace EjemploEntity.Interfaces
{
    public interface ICatalogo
    {
        Task<Respuesta> GetCategoria();
        Task<Respuesta> PostCategoria(Categorium categoria);
        Task<Respuesta> PutCategoria(Categorium categoria);
        Task<Respuesta> GetMarca();
        Task<Respuesta> PostMarca(Marca marca);
        Task<Respuesta> PutMarca(Marca marca);
        Task<Respuesta> GetModelo();
        Task<Respuesta> PostModelo(Modelo modelo);
        Task<Respuesta> PutModelo(Modelo modelo);
        Task<Respuesta> GetCaja();
        Task<Respuesta> PostCaja(Caja caja);
        Task<Respuesta> GetCiudad();
        Task<Respuesta> PostCiudad(Ciudad ciudad);
        Task<Respuesta> GetVendedor(double codVendedor, string? estado);

    }
}
