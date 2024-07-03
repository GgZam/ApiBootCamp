using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VentasController : Controller
    {
        private readonly IVentas _ventas;

        public VentasController (IVentas ventas)
        {
            this._ventas = ventas;
        }

        [HttpGet]
        [Route("GetCliente")]
        public async Task<Respuesta> GetCliente(string? numFactura, double precio, double vendedor, double clienteId)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _ventas.GetCliente(numFactura, precio, vendedor, clienteId);
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }
    }
}
